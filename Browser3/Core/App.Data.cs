using Browser3.Functions;
using Lib.IniFiles.Net6;
using System;
using System.Configuration;
using System.Data.Common;
using System.IO;

namespace Browser3.Core
{
    public static class AppData
    {
        #region Db
        private static string _dbConn_Ups = string.Empty;

        public static string DbConn_Ups
        {
            get { return _dbConn_Ups; }
            set { _dbConn_Ups = value; }
        }

        public static DbCoreMSSQL DbMSSQL
        {
            get;
            set;
        } = new();
        #endregion Db 

        #region Ini file, using only for UI settings
        public static IniFile AppIniFile { get; set; }
        #endregion Ini file


        static AppData()
        {
            string fileName = GetUIConfigFileName();

            AppIniFile = new IniFile(fileName);
        }

        public static string GetUIConfigFileName()
        { 
            string appIniFileName = "ParcelTracker.ini";
            string appIniFileFolder = Environment.ExpandEnvironmentVariables("%AppData%\\1click.lv\\ParcelTracker\\");

            if (!Directory.Exists(appIniFileFolder)) 
            { 
                Directory.CreateDirectory(appIniFileFolder);
            }

            return $"{appIniFileFolder}{appIniFileName}";
        }

        /// <summary>
        ///     Load data from config
        /// </summary>
        public static void Init()
        {
            // Read settings
            string? value = ConfigurationManager.AppSettings["DbConn_Ups"];

            // Check settings
            if (string.IsNullOrEmpty(value))
            {
                throw new NullReferenceException("Connection string cannot be empty");
            }

            // Set settings
            DbConn_Ups = value;

            //
        }
    }
}
