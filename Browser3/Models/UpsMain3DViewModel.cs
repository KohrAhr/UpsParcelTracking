using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Browser3.Types;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveCharts;

namespace Browser3.Models
{
    public partial class UpsMain3DViewModel : ObservableValidator
    {
        [ObservableProperty]
        DateTime? startRange;

        [ObservableProperty]
        DateTime? endRange;

        /// <summary>
        ///     List of Company
        /// </summary>
        [ObservableProperty]
        public ObservableCollection<CommonIdValueObject>? listOfCompany;

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
        ///     Result from 1st Query
        /// </summary>
        [ObservableProperty]
        ObservableCollection<IdValueCommon>? tNs;

        [ObservableProperty]
        SeriesCollection? tNs3D;

        /// <summary>
        ///     2nd query
        /// </summary>
        [ObservableProperty]
        ObservableCollection<IdValueCommon>? tNsView2;

        [ObservableProperty]
        SeriesCollection? tNs3DView2;

        #region Stats/Counts variables
        [ObservableProperty]
        int totalCount;
        #endregion Stats/Counts variables
    }
}
