using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Browser3.Controls;
using Browser3.Types;
using Lib.MVVM.Net6;
using LiveCharts;

namespace Browser3.Models
{
    public class UpsMain3DViewModel : PropertyChangedNotificationEx
    {
        public DateTime? StartRange
        {
            get => GetValue(() => StartRange);
            set => SetValue(() => StartRange, value);
        }

        public DateTime? EndRange
        {
            get => GetValue(() => EndRange);
            set => SetValue(() => EndRange, value);
        }

        /// <summary>
        ///     List of Company
        /// </summary>
        public ObservableCollection<CommonIdValueObject> ListOfCompany
        {
            get => GetValue(() => ListOfCompany);
            set => SetValue(() => ListOfCompany, value);
        }

        /// <summary>
        ///     Selected Company by user
        /// </summary>
        [MaxLength(50)]
        public string SelectedCompany
        {
            get => GetValue(() => SelectedCompany);
            set => SetValue(() => SelectedCompany, value);
        }

        public int? SelectedCompanyID
        {
            get => GetValue(() => SelectedCompanyID);
            set => SetValue(() => SelectedCompanyID, value);
        }

        /// <summary>
        ///     List of Sub Company
        /// </summary>
        public ObservableCollection<CommonIdValueObject> ListOfSubCompany
        {
            get => GetValue(() => ListOfSubCompany);
            set => SetValue(() => ListOfSubCompany, value);
        }

        /// <summary>
        ///     Selected Sub Company by user
        /// </summary>
        [MaxLength(50)]
        public string SelectedSubCompany
        {
            get => GetValue(() => SelectedSubCompany);
            set => SetValue(() => SelectedSubCompany, value);
        }

        /// <summary>
        ///     List of Accounts
        /// </summary>
        public ObservableCollection<CommonIdValueObject> ListOfAccounts
        {
            get => GetValue(() => ListOfAccounts);
            set => SetValue(() => ListOfAccounts, value);
        }

        /// <summary>
        ///     Selected Acccount by user
        /// </summary>
        [MaxLength(50)]
        public string SelectedAccount
        {
            get => GetValue(() => SelectedAccount);
            set => SetValue(() => SelectedAccount, value);
        }

        /// <summary>
        ///     List of Common Phrases
        /// </summary>
        public ObservableCollection<CommonIdValueObject> ListOfCommonPhrases
        {
            get => GetValue(() => ListOfCommonPhrases);
            set => SetValue(() => ListOfCommonPhrases, value);
        }

        /// <summary>
        ///     Selected Common Phrase
        /// </summary>
        [MaxLength(50)]
        public string SelectedCommonPhrase
        {
            get => GetValue(() => SelectedCommonPhrase);
            set => SetValue(() => SelectedCommonPhrase, value);
        }

        [MaxLength(25)]
        public string SelectedTN
        {
            get => GetValue(() => SelectedTN);
            set => SetValue(() => SelectedTN, value);
        }

        /// <summary>
        ///     Result from 1st Query
        /// </summary>
        public ObservableCollection<IdValueCommon> TNs
        {
            get => GetValue(() => TNs);
            set => SetValue(() => TNs, value);
        }

        public SeriesCollection TNs3D
        {
            get => GetValue(() => TNs3D);
            set => SetValue(() => TNs3D, value);
        }

        /// <summary>
        ///     2nd query
        /// </summary>
        public ObservableCollection<IdValueCommon> TNsView2
        {
            get => GetValue(() => TNsView2);
            set => SetValue(() => TNsView2, value);
        }

        public SeriesCollection TNs3DView2
        {
            get => GetValue(() => TNs3DView2);
            set => SetValue(() => TNs3DView2, value);
        }

        #region Stats/Counts variables
        public int TotalCount
        {
            get => GetValue(() => TotalCount);
            set => SetValue(() => TotalCount, value);
        }
        #endregion Stats/Counts variables
    }
}
