using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Browser3.Views;
using Lib.Strings.Net6;
using Lib.UI.Net6;

namespace Browser3.ViewModels
{
    public partial class MainWindowVM
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
            InfoCommand = new RelayCommand(InfoProc);
            UpsMainCommand = new RelayCommand(UpsMainProc);
            UpsMain3DCommand = new RelayCommand(UpsMain3DProc);
        }

        #region Commands implementation
        [RelayCommand]
        void InfoProc()
        {
            CommonDialogs.ShowInfoMessage(
                StringsFunctions.ResourceString("resLblAbout"), 
                StringsFunctions.ResourceString("resLblAboutApp")
            );
        }

        [RelayCommand]
        void UpsMainProc() 
        {
            // Show non modal window -- UPS -- Common View
            WindowsUI.ShowWindow<UpsMainViewWindow>(true);
        }

        [RelayCommand]
        void UpsMain3DProc()
        {
            // Show non modal window -- UPS -- Common View
            WindowsUI.ShowWindow<UpsMain3DViewWindow>(true);
        }
        #endregion Commands implementation 
    }
}
