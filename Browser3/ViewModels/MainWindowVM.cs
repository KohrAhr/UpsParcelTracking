using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Browser3.Views;
using Lib.MVVM.Net6;
using Lib.Strings.Net6;
using Lib.UI.Net6;

namespace Browser3.ViewModels
{
    public class MainWindowVM
    {
        #region Command definition
        public ICommand? InfoCommand { get; set; }
        public ICommand? UpsMainCommand { get; set; }
        public ICommand? UpsMain3DCommand { get; set; }
        #endregion Command definition

        /// <summary>
        ///     Constructor
        /// </summary>
        public MainWindowVM()
        {
            InitCommands();
        }

        public void InitCommands()
        {
            InfoCommand = new RelayCommand(InfoCommandProc);
            UpsMainCommand = new RelayCommand(UpsMainCommandProc);
            UpsMain3DCommand = new RelayCommand(UpsMain3DCommandProc);
        }

        #region Commands implementation
        private void InfoCommandProc(Object aO)
        {
            CommonDialogs.ShowInfoMessage(
                StringsFunctions.ResourceString("resLblAbout"), 
                StringsFunctions.ResourceString("resLblAboutApp")
            );
        }

        private void UpsMainCommandProc(Object aO) 
        {
            // Show non modal window -- UPS -- Common View
            WindowsUI.ShowWindow<UpsMainViewWindow>(true);
        }

        private void UpsMain3DCommandProc(Object aO)
        {
            // Show non modal window -- UPS -- Common View
            WindowsUI.ShowWindow<UpsMain3DViewWindow>(true);
        }
        #endregion Commands implementation 
    }
}
