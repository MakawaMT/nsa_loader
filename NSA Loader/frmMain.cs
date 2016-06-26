using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace NSA_Loader
{
    public partial class frmMain : Form
    {
        private FileSystemWatcher dtaWatcher;//variable that keeps track of changes to DTA files
        
        public frmMain()
        {
            InitializeComponent();
            StartPolling();//start polling
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            GetFileNamesCount();//show file count
            MinimiseToTray();//minimise to tray
        }
        private void OnDtaFileCreated(object sender, FileSystemEventArgs e)
        {

            #region DatabaseFields
            string FIELD_FLOW = "FlowType";
            string FIELD_TRADE = "TradeType";
            string FIELD_HS = "HS";
            string FIELD_PARTNER = "Partner";
            string FIELD_OFFICE = "Office";
            string FIELD_TRANS = "TransType";
            string FIELD_CVALUE = "CValue";
            string FIELD_NET = "NetWeight";
            string FIELD_FREIGHT = "Freight";
            string FIELD_INSURANCE = "Insurance";
            string FIELD_OCHARGES = "OCharges";
            string FIELD_DATE = "Date";
            string FIELD_XXKEY = "XXKey";
            #endregion

            bool isProcessed = false;// keep track of whether the file has been processed or not

            String dtaConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}";//connection string to dta file with place holder to be replaced with dta filename
            String fileName = e.FullPath.ToString();//full path to the dta file

       
            //connection to the dta file itself
            OleDbConnection conn = null;
            try
            {
                //MessageBox.Show(String.Format(dtaConnectionString, fileName));
                conn = new OleDbConnection(String.Format(dtaConnectionString, fileName));
                conn.Open();//open connection
            }
            catch (OleDbException oleDBex)
            {
                WriteLog("OLEDB exception: " + oleDBex.ToString());
                WriteLog("Connection state: " + conn.State.ToString());
                return;
            }
            catch(Exception ex)
            {
                WriteLog("Exception: " + ex.ToString());
                WriteLog("Connection state: " + conn.State.ToString());
                return;
            }

          //  SqlTransaction insertTransaction = null; //transaction to roll back incase of error
            SqlConnection sqlConn =null;
            OleDbDataReader resultsReader=null;
            try
            {

                //query text and command
                String dtaQueryText = "SELECT * FROM Data";
                OleDbCommand queryCommand = new OleDbCommand(dtaQueryText, conn);

                //execute and return the results
                resultsReader = queryCommand.ExecuteReader(CommandBehavior.Default);

                //SQL server credentials
                string[] connLocation = File.ReadAllLines(classes.AppConstants.settingsFile); //access settings file
                string connectionString = connLocation[classes.AppConstants.SQL_CONNECTION_INDEX]; //get connection string from settings file

                sqlConn = new SqlConnection(connectionString);
                sqlConn.Open();//open the connection
           
                string insertRecordText = "INSERT INTO dbo.Customs (FlowType,TradeType,HS,Partner,Office,TransType,CValue,NetWeight,Freight,Insurance,OCharges,Date,XXKey) " +
                       " VALUES (@FlowType,@TradeType,@HS,@Partner,@Office,@TransType,@CValue,@NetWeight,@Freight,@Insurance,@OCharges,@Date,@XXKey)";
                       

                #region OrdinalValues
                //ordinal values etc
                int rowCount = 0;

                int rowFlow = resultsReader.GetOrdinal(FIELD_FLOW);
                int rowTrade = resultsReader.GetOrdinal(FIELD_TRADE);
                int rowHS = resultsReader.GetOrdinal(FIELD_HS);
                int rowPartner = resultsReader.GetOrdinal(FIELD_PARTNER);
                int rowOffice = resultsReader.GetOrdinal(FIELD_OFFICE);
                int rowTrans = resultsReader.GetOrdinal(FIELD_TRANS);
                int rowCValue = resultsReader.GetOrdinal(FIELD_CVALUE);
                int rowNet = resultsReader.GetOrdinal(FIELD_NET);
                int rowFreight = resultsReader.GetOrdinal(FIELD_FREIGHT);
                int rowInsurance = resultsReader.GetOrdinal(FIELD_INSURANCE);
                int rowCharges = resultsReader.GetOrdinal(FIELD_OCHARGES);
                int rowDate = resultsReader.GetOrdinal(FIELD_DATE);
                int rowXXKey = resultsReader.GetOrdinal(FIELD_XXKEY);
                #endregion

           //      insertTransaction = sqlConn.BeginTransaction("RecordsInsert");
                //SqlCommand sqlServerCommand = new SqlCommand(insertRecordText, sqlConn);
               
                //while there are still results in the dataset
                while (resultsReader.Read())
                {
                    /* please fix field types depending on final structure of MSSQL server table*/
                    string valueFlow = resultsReader.GetString(rowFlow);
                    string valueTrade = resultsReader.GetString(rowTrade);
                    string valueHS = resultsReader.GetString(rowHS);
                    string valuePartner = resultsReader.GetString(rowPartner);
                    string valueOffice = resultsReader.GetString(rowOffice);
                    string valueTrans = resultsReader.GetString(rowTrans);
                    
                    string valueCValue = resultsReader.GetValue(rowCValue).ToString().Equals("") ? "" : resultsReader.GetValue(rowCValue).ToString();
                    string valueNet = resultsReader.GetValue(rowNet).ToString().Equals("") ? "" : resultsReader.GetValue(rowNet).ToString();
                    string valueFreight = resultsReader.GetValue(rowFreight).ToString().Equals("") ? "" : resultsReader.GetValue(rowFreight).ToString();
                    string valueInsurance = resultsReader.GetValue(rowInsurance).ToString().Equals("") ? "" : resultsReader.GetValue(rowInsurance).ToString();
                    string valueCharges = resultsReader.GetValue(rowCharges).ToString().Equals("") ? "" : resultsReader.GetValue(rowCharges).ToString();

                    string valueDate = resultsReader.GetValue(rowDate).ToString().Equals("") ? "" : resultsReader.GetValue(rowDate).ToString();
                    string valueXXKey = resultsReader.GetValue(rowXXKey).ToString().Equals(null) ? "" : resultsReader.GetValue(rowXXKey).ToString();

                    #region InsertSQLServer
                    //insert into SQL server
                    SqlCommand sqlServerCommand = new SqlCommand(insertRecordText, sqlConn);
                //    sqlServerCommand.Transaction = insertTransaction;//assign transaction to operation
                    sqlServerCommand.Parameters.AddWithValue("@FlowType", valueFlow);
                    sqlServerCommand.Parameters.AddWithValue("@TradeType", valueTrade);
                    sqlServerCommand.Parameters.AddWithValue("@HS", valueHS);
                    sqlServerCommand.Parameters.AddWithValue("@Partner", valuePartner);
                    sqlServerCommand.Parameters.AddWithValue("@Office", valueOffice);
                    sqlServerCommand.Parameters.AddWithValue("@TransType", valueTrans);
                    sqlServerCommand.Parameters.AddWithValue("@CValue", valueCValue);
                    sqlServerCommand.Parameters.AddWithValue("@NetWeight", valueNet);
                    sqlServerCommand.Parameters.AddWithValue("@Freight", valueFreight);
                    sqlServerCommand.Parameters.AddWithValue("@Insurance", valueInsurance);
                    sqlServerCommand.Parameters.AddWithValue("@OCharges", valueCharges);
                    sqlServerCommand.Parameters.AddWithValue("@Date", valueDate);
                    sqlServerCommand.Parameters.AddWithValue("@XXKey", valueXXKey);

                    sqlServerCommand.ExecuteNonQuery();//execute the query
                    sqlServerCommand.Dispose();//dispose connection

                    #endregion

                    rowCount++;//increment row count
                   
                }//end while

                #region UpdateCounters
                //update manual records
                string[] recordCounter = File.ReadAllLines(classes.AppConstants.recordCountFile);
                int dtaCount = (int.Parse(recordCounter[0].ToString()) + 1);
                int recordsCount = (int.Parse(recordCounter[1].ToString()) + rowCount);
                recordCounter[0] = dtaCount.ToString();
                recordCounter[1] = recordsCount.ToString();
                File.WriteAllLines(classes.AppConstants.recordCountFile, recordCounter);
                #endregion

                isProcessed = true;//whole file is done processing
           //     insertTransaction.Commit();//commit SQL transaction
                notifyNsa.Icon = SystemIcons.Application;
                notifyNsa.Visible = true;
                notifyNsa.Text = Application.ProductName;
                notifyNsa.BalloonTipTitle = Application.ProductName;
                notifyNsa.BalloonTipText = "Done processing: " + e.Name;
                notifyNsa.ShowBalloonTip(2000);

            }
            
            catch (OleDbException oledbEx)
            {
              //  insertTransaction.Rollback("RecordsInsert");
                WriteLog("#OLEDB error on " + e.Name.ToString() + " : " + oledbEx.Message.ToString());
                notifyNsa.Icon = SystemIcons.Application;
                notifyNsa.Visible = true;
                notifyNsa.Text = Application.ProductName;
                notifyNsa.BalloonTipTitle = Application.ProductName;
                notifyNsa.BalloonTipText = "OLEDB Exception: " + e.Name;
                notifyNsa.ShowBalloonTip(2000);
            }
            catch (SqlException sqlEx)
            {
              //  insertTransaction.Rollback("RecordsInsert");
                WriteLog("#SQLException error on " + e.Name.ToString() + " : " + sqlEx.Message.ToString());
                notifyNsa.Icon = SystemIcons.Application;
                notifyNsa.Visible = true;
                notifyNsa.Text = Application.ProductName;
                notifyNsa.BalloonTipTitle = Application.ProductName;
                notifyNsa.BalloonTipText = "SQLException: " + e.Name;
                notifyNsa.ShowBalloonTip(2000);
            }
            catch (FileNotFoundException fnfEx)
            {
              //  insertTransaction.Rollback("RecordsInsert");
                WriteLog("#FileNotFoundException error on " + e.Name.ToString() + " : " + fnfEx.Message.ToString());
                notifyNsa.Icon = SystemIcons.Application;
                notifyNsa.Visible = true;
                notifyNsa.Text = Application.ProductName;
                notifyNsa.BalloonTipTitle = Application.ProductName;
                notifyNsa.BalloonTipText = "FileNotFound: " + e.Name;
                notifyNsa.ShowBalloonTip(2000);
            }
            catch (MalformedLineException mlEx)
            {
              //  insertTransaction.Rollback("RecordsInsert");
                WriteLog("#MalformedLineException error on " + e.Name.ToString() + " : " + mlEx.Message.ToString());
                notifyNsa.Icon = SystemIcons.Application;
                notifyNsa.Visible = true;
                notifyNsa.Text = Application.ProductName;
                notifyNsa.BalloonTipTitle = Application.ProductName;
                notifyNsa.BalloonTipText = "Malformed file error: " + e.Name;
                notifyNsa.ShowBalloonTip(2000);
            }
            catch (Exception ex)
            {
             //   insertTransaction.Rollback("RecordsInsert");
                WriteLog("#Exception error on " + e.Name.ToString() + " : " + ex.Message.ToString());
                notifyNsa.Icon = SystemIcons.Application;
                notifyNsa.Visible = true;
                notifyNsa.Text = Application.ProductName;
                notifyNsa.BalloonTipTitle = Application.ProductName;
                notifyNsa.BalloonTipText = "Exception on: " + e.Name;
                notifyNsa.ShowBalloonTip(2000);
            }
            finally
            {
                //close the objects
                conn.Close();
                resultsReader.Close();
                sqlConn.Close();

                System.Threading.Thread.Sleep(2000);//wait for connection closing and disposal to take place then move dta file to respective folder

                try
                {
                    //move files to either success or fail folder
                    string[] fileNames = File.ReadAllLines(classes.AppConstants.settingsFile);

                    if (isProcessed)//if file has been processed
                    {
                        File.Move(e.FullPath, fileNames[classes.AppConstants.SUCCESS_INDEX] + @"\" + e.Name);
                    }
                    else
                    {
                        File.Move(e.FullPath, fileNames[classes.AppConstants.FAIL_INDEX] + @"\" + e.Name);
                    }
                }
                catch (UnauthorizedAccessException uaEx)
                {
                    WriteLog("Unauthorised access exception on "+e.Name+" : "+uaEx.Message.ToString());
                    notifyNsa.Icon = SystemIcons.Application;
                    notifyNsa.Visible = true;
                    notifyNsa.Text = Application.ProductName;
                    notifyNsa.BalloonTipTitle = Application.ProductName;
                    notifyNsa.BalloonTipText = "Exception occured on move file" + e.Name;
                    notifyNsa.ShowBalloonTip(2000);
                }
                catch (DirectoryNotFoundException dnfEx)
                {
                    WriteLog("Directory not found exception "+ dnfEx.Message.ToString());
                    notifyNsa.Icon = SystemIcons.Application;
                    notifyNsa.Visible = true;
                    notifyNsa.Text = Application.ProductName;
                    notifyNsa.BalloonTipTitle = Application.ProductName;
                    notifyNsa.BalloonTipText = "Exception occured on move file" + e.Name;
                    notifyNsa.ShowBalloonTip(2000);
                }
                catch (Exception ex)
                {
                    WriteLog("Exception on " + e.Name + " : " + ex.Message.ToString());
                    notifyNsa.Icon = SystemIcons.Application;
                    notifyNsa.Visible = true;
                    notifyNsa.Text = Application.ProductName;
                    notifyNsa.BalloonTipTitle = Application.ProductName;
                    notifyNsa.BalloonTipText = "Exception occured on move file" + e.Name;
                    notifyNsa.ShowBalloonTip(2000);
                }
            }
        }
        private void StartPolling()
        {
            try
            {
                dtaWatcher = new FileSystemWatcher();//instantiate the filesystem watcher
                String[] fileNames = File.ReadAllLines(classes.AppConstants.settingsFile);
                //give folder name to monitor
                dtaWatcher.Path = fileNames[classes.AppConstants.POLL_INDEX];
                dtaWatcher.EnableRaisingEvents = true;
                dtaWatcher.Filter = "*.dta";//filter only dta files
                dtaWatcher.Created += new FileSystemEventHandler(OnDtaFileCreated);//event handler for the dta files
                WriteLog("#Started polling on " + dtaWatcher.Path.ToString() + " at " + DateTime.Now.ToString());//write log
            }
            catch (Exception ex)
            {
                WriteLog("#Exception (StartPolling): "+ex.Message.ToString());
            }
        }
        private void StopPolling()
        {
            try
            {
                //dispose of the file watcher object after writing to log
                WriteLog("#Polling stopped on: " + dtaWatcher.Path.ToString());
                dtaWatcher.Dispose();
            }
            catch (Exception ex)
            {
                WriteLog("Exception (StopPolling): " + ex.Message.ToString());
            }
        }
        private void WriteLog(string message)
        {
            //write log to log file then dispose of the object
            StreamWriter logWriter = File.AppendText(classes.AppConstants.logFile);
            logWriter.WriteLine(message);
            logWriter.Flush();
            logWriter.Dispose();
        }
        private void MinimiseToTray()
        {   
                try
                {
                    this.WindowState = FormWindowState.Minimized; //start minimised
                if(this.ShowInTaskbar==true)
                {
                    this.ShowInTaskbar = false;//hide from task bar
                }

                }
                catch (StackOverflowException sofEx)
                {
                    WriteLog("#StackOverFlow Exception (MinimiseToTray): "+sofEx.Message.ToString());
                }
                catch (Exception ex)
                {
                    WriteLog("#Exception(MinimiseToTray): "+ex.Message.ToString());
                }

            
            
            #region ShowNotification
            //show notification balloon with icon and text

            notifyNsa.Icon = SystemIcons.Application;
            notifyNsa.Visible = true;
            notifyNsa.Text = Application.ProductName;
            notifyNsa.BalloonTipTitle = Application.ProductName;
            notifyNsa.BalloonTipText = "NSA DTA app running";
            notifyNsa.ShowBalloonTip(1500);
            #endregion ShowNotification
            //menu items to be shown when the ballon is clicked
            MenuItem[] notifyMenuItems = new MenuItem[2];
            //exit menu item
            notifyMenuItems[0] = new MenuItem();
            notifyMenuItems[0].Text = "Exit";
            notifyMenuItems[0].Click += new System.EventHandler(this.notifyMenuItemsClickHandler);
            //show menu item
            notifyMenuItems[1] = new MenuItem();
            notifyMenuItems[1].Text = "Show";
            notifyMenuItems[1].Click += new System.EventHandler(this.notifyMenuItemsClickHandler);

            //context menu for the notification balloon
            ContextMenu notifyMenu = new ContextMenu();
            notifyMenu.MenuItems.AddRange(notifyMenuItems);//add menu items to context menu

            //add context menu to balloon
            notifyNsa.ContextMenu = notifyMenu;
        }
        private void notifyMenuItemsClickHandler(object sender, EventArgs e)
        {
            //convert item that triggered click to MenuItem and check text to determine action
            MenuItem clickedMenuItem = (MenuItem)sender;
            string menuText = clickedMenuItem.Text;
            menuText = menuText.ToLower();

            switch (menuText)
            {

                case "show":
                    ShowWindow();//show window
                    break;

                case "exit":
                    StopPolling();
                    Application.ExitThread();
                    Application.Exit();//exit application
                    break;

            }
        }
        private void ShowWindow()
        { 
          if (this.ShowInTaskbar == false)
            {
                this.ShowInTaskbar = true; //show in taskbar 
            }

            notifyNsa.Visible = false;//hide notification balloon
            GetFileNamesCount();//update information
        }

        private void GetFileNamesCount()
        {
            try
            {
                //get locations of folders
                string[] fileNames = File.ReadAllLines(classes.AppConstants.settingsFile);
                lblPollDir.Text = fileNames[classes.AppConstants.POLL_INDEX];
                lblSuccessDir.Text = fileNames[classes.AppConstants.SUCCESS_INDEX];
                lblFailDir.Text = fileNames[classes.AppConstants.FAIL_INDEX];
                //get count but reuse filename variable
                fileNames = File.ReadAllLines(classes.AppConstants.recordCountFile);
                lblDTAcount.Text = fileNames[classes.AppConstants.DTA_COUNT_INDEX];
                lblRecordCount.Text = fileNames[classes.AppConstants.RECORD_COUNT_INDEX];
            }
            catch (FileNotFoundException fnfEx)
            {
                MessageBox.Show("File not found: " + fnfEx.Message);
                WriteLog("#FileNotFound;getFile: " + "(" + fnfEx.FileName + ")" + fnfEx.Message + " Time: " + DateTime.Now.ToString());
            }
            catch (IndexOutOfRangeException iofrEx)
            {
                MessageBox.Show("Index out of range: " + iofrEx.Message);
                WriteLog("#IndexOutOfRange;getFile: " + iofrEx.Message + " Time: " + DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: " + ex.Message);
                WriteLog("#Exception;getFile: " + ex.Message + " Time: " + DateTime.Now.ToString());
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                MinimiseToTray();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            MinimiseToTray();//minimise to tray
            e.Cancel = true;//stop application from being closed
        }

        private void notifyNsa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowWindow();//show window
        }

        private void pollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserNsa.Description = "Select new poll folder";
            folderBrowserNsa.ShowDialog();
            if (!folderBrowserNsa.SelectedPath.ToString().Equals(""))
            {
                UpdateDirLocation(folderBrowserNsa.SelectedPath, classes.AppConstants.POLL_INDEX);
            }
        }

        private void successToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserNsa.Description = "Select new success folder";
            folderBrowserNsa.ShowDialog();
            if (!folderBrowserNsa.SelectedPath.ToString().Equals(""))
            {
                UpdateDirLocation(folderBrowserNsa.SelectedPath, classes.AppConstants.SUCCESS_INDEX);
            }
        }

        private void failToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserNsa.Description = "Select new fail folder";
            folderBrowserNsa.ShowDialog();
            if (!folderBrowserNsa.SelectedPath.ToString().Equals(""))
            {
                UpdateDirLocation(folderBrowserNsa.SelectedPath, classes.AppConstants.FAIL_INDEX);
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();//restart the application
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();//exit the application
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartPolling();//start polling
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopPolling();//stop polling
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string helpMessage;
            string copyright = "©";
            helpMessage = String.Format("Application for {0}. Contact {1} at {2}." + "\n" + "Rights reserved {3}", "NSA", "Digital Pangea", "+264 85 551 0088", copyright);
            MessageBox.Show(helpMessage, Application.ProductName);

        }
        private void UpdateDirLocation(string newLocation, int index)
        {
            try
            {
                //update directory location
                string[] fileNames = File.ReadAllLines(classes.AppConstants.settingsFile);
                fileNames[index] = newLocation;
                File.WriteAllLines(classes.AppConstants.settingsFile, fileNames);
                //show new directory locations
                GetFileNamesCount();
                //restart the polling process
                StopPolling();
                StartPolling();
            }
            catch (FileNotFoundException fnfEx)
            {
                MessageBox.Show("File not found: " + fnfEx.Message);
                WriteLog("#FileNotFound; updateDir: " + "(" + fnfEx.FileName + ") : " + fnfEx.Message + " Time: " + DateTime.Now.ToString());
            }
            catch (IndexOutOfRangeException iofrEx)
            {
                MessageBox.Show("Index out of range: " + iofrEx.Message);
                WriteLog("#IndexOutOfRange; updateDir: " + iofrEx.Message + " Time: " + DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: " + ex.Message);
                WriteLog("#Exception; updateDir: " + ex.Message + " Time: " + DateTime.Now.ToString());
            }
        }

        private void connectionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string[] connLocation = File.ReadAllLines(classes.AppConstants.settingsFile); //access settings file
                string connectionString = connLocation[classes.AppConstants.SQL_CONNECTION_INDEX]; //get connection string from settings file

               SqlConnection sqlConn = new SqlConnection(connectionString);
               sqlConn.Open();//open the connection
                WriteLog("#SQL Connection state: " + sqlConn.State);
            }
            catch (Exception ex) {
                WriteLog("#Error on SQL connection: " + ex.ToString());
            }
        }
    }

}
