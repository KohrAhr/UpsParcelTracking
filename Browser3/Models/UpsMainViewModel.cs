using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Browser3.Types;
using Lib.MVVM.Net6;

namespace Browser3.Models
{
    public class UpsMainViewModel : PropertyChangedNotificationEx
    {
        /// <summary>
        ///     Currently selected entry in DataGrid
        /// </summary>
        public TNBaseEx SelectedItem
        {
            get => GetValue(() => SelectedItem);
            set => SetValue(() => SelectedItem, value);
        }

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
        ///     Using for DataGrid
        ///     Tracking Numbers and common info about them
        /// </summary>
        public ObservableCollection<TNBaseEx> TNs
        {
            get => GetValue(() => TNs);
            set => SetValue(() => TNs, value);
        }

        public string TextForHighlight
        {
            get => GetValue(() => TextForHighlight);
            set => SetValue(() => TextForHighlight, value);
        }

        /// <summary>
        /// </summary>
        public ObservableCollection<CommonIdValueObject> ShowTop
        {
            get => GetValue(() => ShowTop);
            set => SetValue(() => ShowTop, value);
        }

        /// <summary>
        /// </summary>
        [MaxLength(7)]
        public string SelectedShowTop
        {
            get => GetValue(() => SelectedShowTop);
            set => SetValue(() => SelectedShowTop, value);
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
        ///     List of Shipping Status
        /// </summary>
        public ObservableCollection<CommonIdValueObject> ListOfShippingStatuses
        {
            get => GetValue(() => ListOfShippingStatuses);
            set => SetValue(() => ListOfShippingStatuses, value);
        }

        public int? SelectedShippingStatus
        {
            get => GetValue(() => SelectedShippingStatus);
            set => SetValue(() => SelectedShippingStatus, value);
        }

        /// <summary>
        ///     List of Late Status
        /// </summary>
        public ObservableCollection<CommonIdValueObject> ListOfLateStatuses
        {
            get => GetValue(() => ListOfLateStatuses);
            set => SetValue(() => ListOfLateStatuses, value);
        }

        public int? SelectedLateStatus
        {
            get => GetValue(() => SelectedLateStatus);
            set => SetValue(() => SelectedLateStatus, value);
        }

        #region Stats/Counts variables
        public int TotalCount
        {
            get => GetValue(() => TotalCount);
            set => SetValue(() => TotalCount, value);
        }

        public int TotalCountAfterFilter
        {
            get => GetValue(() => TotalCountAfterFilter);
            set => SetValue(() => TotalCountAfterFilter, value);
        }

        public int TotalCountAfterAddonFilter
        {
            get => GetValue(() => TotalCountAfterAddonFilter);
            set => SetValue(() => TotalCountAfterAddonFilter, value);
        }
        #endregion Stats/Counts variables
    }
}
