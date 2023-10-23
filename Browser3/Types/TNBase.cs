using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Browser3.Types
{
    /// <summary>
    ///     Table: TNs
    /// </summary>
    public partial class TNBase : ObservableValidator
    {
        /// <summary>
        ///     Identity. 
        ///     PK.
        /// </summary>
        [ObservableProperty]
        int tNID;

        [ObservableProperty]
        int tNCompanyID;

        [MaxLength(50)]
        [ObservableProperty]
        string? tNSubCompany;

        [MaxLength(50)]
        [ObservableProperty]
        string? tNAccountID;

        [MaxLength(25)]
        [ObservableProperty]
        string tNTrackingNumber = string.Empty;

        /// <summary>
        ///     UPS Service code. Stored as TEXT.
        ///     Samples: 003 03 26
        ///     Theoretically could be converted into Int
        /// </summary>
        [MaxLength(50)]
        [ObservableProperty]
        string? tNServiceCode;

        /// <summary>
        ///     UPS Service code -- translated as Text
        /// </summary>
        [MaxLength(50)]
        [ObservableProperty]
        string? tNService;

        [ObservableProperty]
        float? tNWeightLbs;

        [MaxLength(100)]
        [ObservableProperty]
        string? tNShipToCity;

        [MaxLength(25)]
        [ObservableProperty]
        string? tNShipToState;

        [MaxLength(25)]
        [ObservableProperty]
        string? tNShipToZIP;

        [MaxLength(2)]
        [ObservableProperty]
        string? tNShipToCountry;

        [MaxLength(100)]
        [ObservableProperty]
        string? tNShipFromCity;

        [MaxLength(25)]
        [ObservableProperty]
        string? tNShipFromState;

        [MaxLength(25)]
        [ObservableProperty]
        string? tNShipFromZIP;

        [MaxLength(2)]
        [ObservableProperty]
        string? tNShipFromCountry;

        /// <summary>
        ///     ?
        /// </summary>
        [ObservableProperty]
        int? tNShippingStatus;

        /// <summary>
        ///     Not using anymore
        /// </summary>
        [ObservableProperty]
        SqlMoney? tNShippingCost;

        [ObservableProperty]
        DateTime? tNShippedDate;

        [ObservableProperty]
        DateTime? tNScheduledDate;

        [ObservableProperty]
        DateTime? tNDeliveredDate;

        /// <summary>
        ///     Default value is False
        /// </summary>
        [ObservableProperty]
        bool? sysIsChecked;

        [ObservableProperty]
        bool? sysIsError;

        /// <summary>
        ///     Default value is 0
        /// </summary>
        [ObservableProperty]
        int? sysStatus;

        [ObservableProperty]
        int? lateStatus;

        /// <summary>
        ///     Refund Request Send status
        ///     Default value is False
        /// </summary>
        [ObservableProperty]
        bool? rRSStatus;

        /// <summary>
        ///     Contain date when TN has been added into Db
        /// </summary>
        [ObservableProperty]
        DateTime? sysDateTimeImport;

        /// <summary>
        ///     Contain date when TN has been tracked last time
        /// </summary>
        [ObservableProperty]
        DateTime? sysDateTimeTrack;

        /// <summary>
        ///     Contain deadline date when package should be delivered
        /// </summary>
        [ObservableProperty]
        DateTime? sysDateTimeSchedule;

        /// <summary>
        ///     Contain date when Refund Request has been made
        /// </summary>
        [ObservableProperty]
        DateTime? sysDateTimeRefundRequest;

        /// <summary>
        ///     Last technical error, if any
        /// </summary>
        [MaxLength(250)]
        [ObservableProperty]
        string? errorMessage;

        /// <summary>
        ///     To be moved into different Table
        /// </summary>
        [ObservableProperty]
        public string? tNTrackHTML;

        /// <summary>
        ///     To be moved into different Table
        /// </summary>
        [ObservableProperty]
        string? tNTrackXML;

        /// <summary>
        ///     To be moved into different Table
        /// </summary>
        [ObservableProperty]
        string? tNScheduleXML;
    }
}
