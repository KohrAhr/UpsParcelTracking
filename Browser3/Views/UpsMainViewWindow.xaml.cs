using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Browser3.Controls;
using Browser3.Functions;
using Browser3.Models;
using Browser3.Types;
using Browser3.ViewModels;
using Browser3.Views.Base;
using Lib.Data;

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

            // ??
            RefreshMainDataGridCommand = ((UpsMainViewWindowVM)DataContext).RefreshCommand;
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

        //private void MainFilterBar_FilterChanged(object sender, RoutedEventArgs e)
        //{
        //    RefreshMainDataGridCommand?.Execute(null);
        //}
    }
}
