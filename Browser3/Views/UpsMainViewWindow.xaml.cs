using System.Windows;
using System.Windows.Controls;
using Browser3.Controls;
using Browser3.Functions;
using Browser3.Types;
using Browser3.ViewModels;
using Browser3.Views.Base;

namespace Browser3.Views
{
    /// <summary>
    /// Interaction logic for UpsMainViewWindow.xaml
    /// </summary>
    public partial class UpsMainViewWindow : BaseMainViewWindow
    {
        public UpsMainViewWindow()
        {
            InitializeComponent();

            RefreshMainDataGridCommand = ((UpsMainViewWindowVM)DataContext).RefreshProcCommand;
        }

        private void quickSearch_TextForSearchChanged(object sender, RoutedEventArgs e)
        {
            TextBox textBoxName = ((QuickSearch)sender).txtSearch;
            string filterText = textBoxName.Text.ToUpper();

            DataGridFunctions.FilterGridView<TNBase>(dgTNView.ItemsSource, filterText);

            ((UpsMainViewWindowVM)DataContext).Model.TotalCountAfterAddonFilter = dgTNView.Items.Count;
        }

        private void quickSearch_TextForHighlightChanged(object sender, RoutedEventArgs e)
        {
            TextBox textBoxName = ((QuickSearch)sender).txtHighlight;
            string filterText = textBoxName.Text.ToUpper();

            ((UpsMainViewWindowVM)DataContext).Model.TextForHighlight = filterText;
        }
    }
}
