using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Browser3.Views.Base
{
    /// <summary>
    /// Interaction logic for BaseMainViewWindow.xaml
    /// </summary>
    public class BaseMainViewWindow : BaseWindow
    {
        public ICommand? RefreshMainDataGridCommand { get; set; }

        public DataGrid? MainDataGrid { get; set; }

        public virtual void ComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                // refresh ?
                RefreshMainDataGridCommand?.Execute(null);
            }
        }

    }
}
