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
using LiveCharts;
using LiveCharts.Wpf;

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
            RefreshMainDataGridCommand = ((UpsMain3DViewWindowVM)DataContext).RefreshCommand;
        }
    }
}
