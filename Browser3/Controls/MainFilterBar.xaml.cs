using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Browser3.Types;

namespace Browser3.Controls
{
    /// <summary>
    /// Interaction logic for MainFilterBar.xaml
    /// </summary>
    public partial class MainFilterBar : UserControl
    {
        /// <summary>
        ///     Public Event. Using for catch hitted Enter
        /// </summary>
        public event EventHandler<KeyEventArgs>? FilterChanged = null;

        // #1

        public static readonly DependencyProperty ListOfCompanyProperty = DependencyProperty.Register
        (
           "ListOfCompany",
           typeof(ObservableCollection<CommonIdValueObject>),
           typeof(MainFilterBar),
           new PropertyMetadata(null)
        );

        /// <summary>
        ///     List of Company
        /// </summary>
        public ObservableCollection<CommonIdValueObject> ListOfCompany
        {
            get
            {
                return (ObservableCollection<CommonIdValueObject>)GetValue(ListOfCompanyProperty);
            }
            set
            {
                SetValue(ListOfCompanyProperty, value);
            }
        }

        // #2

        public static readonly DependencyProperty SelectedCompanyIDProperty = DependencyProperty.Register
        (
           "SelectedCompanyID",
           typeof(int?),
           typeof(MainFilterBar),
           new PropertyMetadata(null)
        );

        public int? SelectedCompanyID
        {
            get
            {
                return (int?)GetValue(SelectedCompanyIDProperty);
            }
            set
            {
                SetValue(SelectedCompanyIDProperty, value);
            }
        }

        // #3

        public static readonly DependencyProperty ListOfSubCompanyProperty = DependencyProperty.Register
        (
           "ListOfSubCompany",
           typeof(ObservableCollection<CommonIdValueObject>),
           typeof(MainFilterBar),
           new PropertyMetadata(null)
        );

        /// <summary>
        ///     List of Sub Company
        /// </summary>
        public ObservableCollection<CommonIdValueObject> ListOfSubCompany
        {
            get
            {
                return (ObservableCollection<CommonIdValueObject>)GetValue(ListOfSubCompanyProperty);
            }
            set
            {
                SetValue(ListOfSubCompanyProperty, value);
            }
        }

        // #4

        public static readonly DependencyProperty SelectedSubCompanyProperty = DependencyProperty.Register
        (
           "SelectedSubCompany",
           typeof(string),
           typeof(MainFilterBar),
           new PropertyMetadata(null)
        );

        public string SelectedSubCompany
        {
            get
            {
                return (string)GetValue(SelectedSubCompanyProperty);
            }
            set
            {
                SetValue(SelectedSubCompanyProperty, value);
            }
        }

        // #5

        public static readonly DependencyProperty ListOfAccountsProperty = DependencyProperty.Register
        (
           "ListOfAccounts",
           typeof(ObservableCollection<CommonIdValueObject>),
           typeof(MainFilterBar),
           new PropertyMetadata(null)
        );

        /// <summary>
        ///     List of Accounts
        /// </summary>
        public ObservableCollection<CommonIdValueObject> ListOfAccounts
        {
            get
            {
                return (ObservableCollection<CommonIdValueObject>)GetValue(ListOfAccountsProperty);
            }
            set
            {
                SetValue(ListOfAccountsProperty, value);
            }
        }

        // #6

        public static readonly DependencyProperty SelectedAccountProperty = DependencyProperty.Register
        (
           "SelectedAccount",
           typeof(string),
           typeof(MainFilterBar),
           new PropertyMetadata(null)
        );

        /// <summary>
        ///     Selected Acccount by user
        /// </summary>
        public string SelectedAccount
        {
            get
            {
                return (string)GetValue(SelectedAccountProperty);
            }
            set
            {
                SetValue(SelectedAccountProperty, value);
            }
        }

        // #7

        /// <summary>
        ///     List of Common Phrases
        /// </summary>
        public static readonly DependencyProperty ListOfCommonPhrasesProperty = DependencyProperty.Register
        (
           "ListOfCommonPhrases",
           typeof(ObservableCollection<CommonIdValueObject>),
           typeof(MainFilterBar),
           new PropertyMetadata(null)
        );

        public ObservableCollection<CommonIdValueObject> ListOfCommonPhrases
        {
            get
            {
                return (ObservableCollection<CommonIdValueObject>)GetValue(ListOfCommonPhrasesProperty);
            }
            set
            {
                SetValue(ListOfCommonPhrasesProperty, value);
            }
        }

        // #8

        public static readonly DependencyProperty SelectedCommonPhraseProperty = DependencyProperty.Register
        (
           "SelectedCommonPhrase",
           typeof(string),
           typeof(MainFilterBar),
           new PropertyMetadata(null)
        );

        public string SelectedCommonPhrase
        {
            get
            {
                return (string)GetValue(SelectedCommonPhraseProperty);
            }
            set
            {
                SetValue(SelectedCommonPhraseProperty, value);
            }
        }

        // #9

        public static readonly DependencyProperty SelectedTNProperty = DependencyProperty.Register
        (
           "SelectedTN",
           typeof(string),
           typeof(MainFilterBar),
           new PropertyMetadata(null)
        );

        public string SelectedTN
        {
            get
            {
                return (string)GetValue(SelectedTNProperty);
            }
            set
            {
                SetValue(SelectedTNProperty, value);
            }
        }

        // #9


        /// <summary>
        ///     Constructor
        /// </summary>

        public MainFilterBar()
        {
            InitializeComponent();
        }

        private void ComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            FilterChanged?.Invoke(sender, e);
        }
    }
}
