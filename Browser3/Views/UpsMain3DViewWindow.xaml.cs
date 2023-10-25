using Browser3.ViewModels;
using Browser3.Views.Base;

namespace Browser3.Views
{
    /// <summary>
    /// Interaction logic for UpsMainViewWindow.xaml
    /// </summary>
    public partial class UpsMain3DViewWindow : BaseMainViewWindow
    {
        public UpsMain3DViewWindow()
        {
            InitializeComponent();

            // ??
            RefreshMainDataGridCommand = ((UpsMain3DViewWindowVM)DataContext).RefreshProcCommand;
        }
    }
}
