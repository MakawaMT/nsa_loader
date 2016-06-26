using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSA_Loader.classes
{
    class AppConstants
    {
        public static string settingsFile = @"C:\nsa\settings.txt";
        public static string recordCountFile = @"C:\nsa\record_count.txt";
        public static string logFile = @"C:\nsa\log.txt";
        public static int POLL_INDEX = 0;
        public static int SUCCESS_INDEX = 1;
        public static int FAIL_INDEX = 2;
        public static int SQL_CONNECTION_INDEX = 3;
        public static int DTA_COUNT_INDEX = 0;
        public static int RECORD_COUNT_INDEX = 1;

        
    }
}
