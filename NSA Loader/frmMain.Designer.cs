namespace NSA_Loader
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.successToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.failToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFailDir = new System.Windows.Forms.Label();
            this.lblSuccessDir = new System.Windows.Forms.Label();
            this.lblPollDir = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.lblDTAcount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserNsa = new System.Windows.Forms.FolderBrowserDialog();
            this.notifyNsa = new System.Windows.Forms.NotifyIcon(this.components);
            this.connectionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.applicationToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(638, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.directoriesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(78, 25);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // directoriesToolStripMenuItem
            // 
            this.directoriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pollToolStripMenuItem,
            this.successToolStripMenuItem,
            this.failToolStripMenuItem});
            this.directoriesToolStripMenuItem.Name = "directoriesToolStripMenuItem";
            this.directoriesToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.directoriesToolStripMenuItem.Text = "Directories";
            // 
            // pollToolStripMenuItem
            // 
            this.pollToolStripMenuItem.Name = "pollToolStripMenuItem";
            this.pollToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.pollToolStripMenuItem.Text = "Poll";
            this.pollToolStripMenuItem.Click += new System.EventHandler(this.pollToolStripMenuItem_Click);
            // 
            // successToolStripMenuItem
            // 
            this.successToolStripMenuItem.Name = "successToolStripMenuItem";
            this.successToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.successToolStripMenuItem.Text = "Success";
            this.successToolStripMenuItem.Click += new System.EventHandler(this.successToolStripMenuItem_Click);
            // 
            // failToolStripMenuItem
            // 
            this.failToolStripMenuItem.Name = "failToolStripMenuItem";
            this.failToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.failToolStripMenuItem.Text = "Fail";
            this.failToolStripMenuItem.Click += new System.EventHandler(this.failToolStripMenuItem_Click);
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.pollToolStripMenuItem1,
            this.connectionTestToolStripMenuItem});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(100, 25);
            this.applicationToolStripMenuItem.Text = "Application";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pollToolStripMenuItem1
            // 
            this.pollToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.pollToolStripMenuItem1.Name = "pollToolStripMenuItem1";
            this.pollToolStripMenuItem1.Size = new System.Drawing.Size(189, 26);
            this.pollToolStripMenuItem1.Text = "Poll";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(112, 26);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(112, 26);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFailDir);
            this.groupBox1.Controls.Add(this.lblSuccessDir);
            this.groupBox1.Controls.Add(this.lblPollDir);
            this.groupBox1.Controls.Add(this.lblRecordCount);
            this.groupBox1.Controls.Add(this.lblDTAcount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 313);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // lblFailDir
            // 
            this.lblFailDir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFailDir.Location = new System.Drawing.Point(232, 213);
            this.lblFailDir.Name = "lblFailDir";
            this.lblFailDir.Size = new System.Drawing.Size(310, 31);
            this.lblFailDir.TabIndex = 15;
            // 
            // lblSuccessDir
            // 
            this.lblSuccessDir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSuccessDir.Location = new System.Drawing.Point(232, 171);
            this.lblSuccessDir.Name = "lblSuccessDir";
            this.lblSuccessDir.Size = new System.Drawing.Size(310, 31);
            this.lblSuccessDir.TabIndex = 14;
            // 
            // lblPollDir
            // 
            this.lblPollDir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPollDir.Location = new System.Drawing.Point(232, 127);
            this.lblPollDir.Name = "lblPollDir";
            this.lblPollDir.Size = new System.Drawing.Size(310, 31);
            this.lblPollDir.TabIndex = 13;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRecordCount.Location = new System.Drawing.Point(232, 85);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(216, 31);
            this.lblRecordCount.TabIndex = 12;
            // 
            // lblDTAcount
            // 
            this.lblDTAcount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDTAcount.Location = new System.Drawing.Point(232, 41);
            this.lblDTAcount.Name = "lblDTAcount";
            this.lblDTAcount.Size = new System.Drawing.Size(143, 31);
            this.lblDTAcount.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(106, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fail Directory:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(70, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Success Directory:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(106, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Poll Directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(99, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Record Count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "DTA Count:";
            // 
            // notifyNsa
            // 
            this.notifyNsa.Text = "notifyIcon1";
            this.notifyNsa.Visible = true;
            this.notifyNsa.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyNsa_MouseDoubleClick);
            // 
            // connectionTestToolStripMenuItem
            // 
            this.connectionTestToolStripMenuItem.Name = "connectionTestToolStripMenuItem";
            this.connectionTestToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.connectionTestToolStripMenuItem.Text = "Connection Test";
            this.connectionTestToolStripMenuItem.Click += new System.EventHandler(this.connectionTestToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 366);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem successToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem failToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFailDir;
        private System.Windows.Forms.Label lblSuccessDir;
        private System.Windows.Forms.Label lblPollDir;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label lblDTAcount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserNsa;
        private System.Windows.Forms.NotifyIcon notifyNsa;
        private System.Windows.Forms.ToolStripMenuItem connectionTestToolStripMenuItem;
    }
}

