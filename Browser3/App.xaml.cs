using Browser3.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Browser3.Views;

namespace Browser3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Load config

        private void AppStartup(object sender, StartupEventArgs e)
        {
            AppData.Init();

            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            // DB.
            AppData.DbMSSQL.OpenConnection(AppData.DbConn_Ups);


            Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
