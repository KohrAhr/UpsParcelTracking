using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Browser3.Types;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Browser3.Models
{
    public partial class UpsMainViewModel : ObservableValidator
    {
        /// <summary>
        ///     Currently selected entry in DataGrid
        /// </summary>
        [ObservableProperty]
        TNBaseEx? selectedItem;

        [ObservableProperty]
        DateTime? startRange;

        [ObservableProperty]
        DateTime? endRange;

        /// <summary>
        ///     Using for DataGrid
        ///     Tracking Numbers and common info about them
        /// </summary>
        [ObservableProperty]
        ObservableCollection<TNBaseEx>? tNs;

        [ObservableProperty]
        string textForHighlight = string.Empty;

        /// <summary>
        /// </summary>
        [ObservableProperty]
        ObservableCollection<CommonIdValueObject>? showTop;

        /// <summary>
        /// </summary>
        [MaxLength(7)]
        [ObservableProperty]
        string selectedShowTop = string.Empty;

        /// <summary>
        ///     List of Company
        /// </summary>
        [ObservableProperty]
        ObservableCollection<CommonIdValueObject>? listOfCompany;

        /// <summary>
        ///     Selected Company by user
        /// </summary>
        [MaxLength(50)]
        [ObservableProperty]
        string selectedCompany = string.Empty;

        [ObservableProperty]
        int? selectedCompanyID;

        /// <summary>
        ///     List of Sub Company
        /// </summary>
        [ObservableProperty]
        ObservableCollection<CommonIdValueObject>? listOfSubCompany;

        /// <summary>
        ///     Selected Sub Company by user
        /// </summary>
        [MaxLength(50)]
        [ObservableProperty]
        string selectedSubCompany = string.Empty;

        /// <summary>
        ///     List of Accounts
        /// </summary>
        [ObservableProperty]
        ObservableCollection<CommonIdValueObject>? listOfAccounts;

        /// <summary>
        ///     Selected Acccount by user
        /// </summary>
        [MaxLength(50)]
        [ObservableProperty]
        string selectedAccount = string.Empty;

        /// <summary>
        ///     List of Common Phrases
        /// </summary>
        [ObservableProperty]
        ObservableCollection<CommonIdValueObject>? listOfCommonPhrases;

        /// <summary>
        ///     Selected Common Phrase
        /// </summary>
        [MaxLength(50)]
        [ObservableProperty]
        string selectedCommonPhrase = string.Empty;

        [MaxLength(25)]
        [ObservableProperty]
        string selectedTN = string.Empty;

        /// <summary>
        ///     List of Shipping Status
        /// </summary>
        [ObservableProperty]
        ObservableCollection<CommonIdValueObject>? listOfShippingStatuses;

        [ObservableProperty]
        int? selectedShippingStatus;

        /// <summary>
        ///     List of Late Status
        /// </summary>
        [ObservableProperty]
        ObservableCollection<CommonIdValueObject>? listOfLateStatuses;

        [ObservableProperty]
        int? selectedLateStatus;

        #region Stats/Counts variables
        [ObservableProperty]
        int totalCount;

        [ObservableProperty]
        int totalCountAfterFilter;

        [ObservableProperty]
        int totalCountAfterAddonFilter;
        #endregion Stats/Counts variables
    }
}
