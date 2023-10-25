using System.Windows;
using System.Windows.Controls;

namespace Browser3.Controls
{
    /// <summary>
    /// Interaction logic for QuickSearch.xaml
    /// </summary>
    public partial class QuickSearch : UserControl
    {
        public event RoutedEventHandler? TextForSearchChanged = null;
        public event RoutedEventHandler? TextForHighlightChanged = null;

        public string TextSearch
        {
            get
            {
                return txtSearch.Text.ToUpper();
            }
            set
            {
                txtSearch.Text = value;
            }
        }

        public string TextHighlight
        {
            get
            {
                return txtHighlight.Text.ToUpper();
            }
            set
            {
                txtHighlight.Text = value;
            }
        }

        public QuickSearch()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBoxName = (TextBox)sender;
            string filterText = textBoxName.Text.ToUpper();

            // Call event
            if (TextForSearchChanged != null)
            {
                TextForSearchChanged(this, new RoutedEventArgs());
            }
        }

        private void btnResetSearch_Click(object sender, RoutedEventArgs e)
        {
            ResetSearch();
        }

        private void btnResetHighlight_Click(object sender, RoutedEventArgs e)
        {
            ResetHighlight();
        }

        private void ResetSearch()
        {
            TextSearch = string.Empty;
        }

        private void ResetHighlight()
        {
            TextHighlight = string.Empty;
        }

        private void txtHighlight_TextChanged(object sender, TextChangedEventArgs e)
        {
            //
            TextBox textBoxName = (TextBox)sender;
            string filterText = textBoxName.Text.ToUpper();

            // Call event
            if (TextForHighlightChanged != null)
            {
                TextForHighlightChanged(this, new RoutedEventArgs());
            }
        }
    }
}
