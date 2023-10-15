using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.MVVM.Net6;

namespace Browser3.Types
{
    /// <summary>
    ///     Table: TNs
    /// </summary>
    public class TNBase : PropertyChangedNotificationEx
    {
        /// <summary>
        ///     Identity. 
        ///     PK.
        /// </summary>
        public int TNID
        {
            get => GetValue(() => TNID);
            set => SetValue(() => TNID, value);
        }

        public int TNCompanyID
        {
            get => GetValue(() => TNCompanyID);
            set => SetValue(() => TNCompanyID, value);
        }

        [MaxLength(50)]
        public string? TNSubCompany
        {
            get => GetValue(() => TNSubCompany);
            set => SetValue(() => TNSubCompany, value);
        }

        [MaxLength(50)]
        public string? TNAccountID
        {
            get => GetValue(() => TNAccountID);
            set => SetValue(() => TNAccountID, value);
        }

        [MaxLength(25)]
        public string TNTrackingNumber
        {
            get => GetValue(() => TNTrackingNumber);
            set => SetValue(() => TNTrackingNumber, value);
        }

        /// <summary>
        ///     UPS Service code. Stored as TEXT.
        ///     Samples: 003 03 26
        ///     Theoretically could be converted into Int
        /// </summary>
        [MaxLength(50)]
        public string? TNServiceCode
        {
            get => GetValue(() => TNServiceCode);
            set => SetValue(() => TNServiceCode, value);
        }

        /// <summary>
        ///     UPS Service code -- translated as Text
        /// </summary>
        [MaxLength(50)]
        public string? TNService
        {
            get => GetValue(() => TNService);
            set => SetValue(() => TNService, value);
        }

        public float? TNWeightLbs
        {
            get => GetValue(() => TNWeightLbs);
            set => SetValue(() => TNWeightLbs, value);
        }

        [MaxLength(100)]
        public string? TNShipToCity
        {
            get => GetValue(() => TNShipToCity);
            set => SetValue(() => TNShipToCity, value);
        }

        [MaxLength(25)]
        public string? TNShipToState
        {
            get => GetValue(() => TNShipToState);
            set => SetValue(() => TNShipToState, value);
        }

        [MaxLength(25)]
        public string? TNShipToZIP
        {
            get => GetValue(() => TNShipToZIP);
            set => SetValue(() => TNShipToZIP, value);
        }

        [MaxLength(2)]
        public string? TNShipToCountry
        {
            get => GetValue(() => TNShipToCountry);
            set => SetValue(() => TNShipToCountry, value);
        }

        [MaxLength(100)]
        public string? TNShipFromCity
        {
            get => GetValue(() => TNShipFromCity);
            set => SetValue(() => TNShipFromCity, value);
        }

        [MaxLength(25)]
        public string? TNShipFromState
        {
            get => GetValue(() => TNShipFromState);
            set => SetValue(() => TNShipFromState, value);
        }

        [MaxLength(25)]
        public string? TNShipFromZIP
        {
            get => GetValue(() => TNShipFromZIP);
            set => SetValue(() => TNShipFromZIP, value);
        }

        [MaxLength(2)]
        public string? TNShipFromCountry
        {
            get => GetValue(() => TNShipFromCountry);
            set => SetValue(() => TNShipFromCountry, value);
        }

        /// <summary>
        ///     ?
        /// </summary>
        public int? TNShippingStatus
        {
            get => GetValue(() => TNShippingStatus);
            set => SetValue(() => TNShippingStatus, value);
        }

        /// <summary>
        ///     Not using anymore
        /// </summary>
        public SqlMoney? TNShippingCost
        {
            get => GetValue(() => TNShippingCost);
            set => SetValue(() => TNShippingCost, value);
        }

        public DateTime? TNShippedDate
        {
            get => GetValue(() => TNShippedDate);
            set => SetValue(() => TNShippedDate, value);
        }

        public DateTime? TNScheduledDate
        {
            get => GetValue(() => TNScheduledDate);
            set => SetValue(() => TNScheduledDate, value);
        }

        public DateTime? TNDeliveredDate
        {
            get => GetValue(() => TNDeliveredDate);
            set => SetValue(() => TNDeliveredDate, value);
        }

        /// <summary>
        ///     Default value is False
        /// </summary>
        public bool? SysIsChecked
        {
            get => GetValue(() => SysIsChecked);
            set => SetValue(() => SysIsChecked, value);
        }

        public bool? SysIsError
        {
            get => GetValue(() => SysIsError);
            set => SetValue(() => SysIsError, value);
        }

        /// <summary>
        ///     Default value is 0
        /// </summary>
        public int? SysStatus
        {
            get => GetValue(() => SysStatus);
            set => SetValue(() => SysStatus, value);
        }

        public int? LateStatus
        {
            get => GetValue(() => LateStatus);
            set => SetValue(() => LateStatus, value);
        }

        /// <summary>
        ///     Refund Request Send status
        ///     Default value is False
        /// </summary>
        public bool? RRSStatus
        {
            get => GetValue(() => RRSStatus);
            set => SetValue(() => RRSStatus, value);
        }

        /// <summary>
        ///     Contain date when TN has been added into Db
        /// </summary>
        public DateTime? SysDateTimeImport
        {
            get => GetValue(() => SysDateTimeImport);
            set => SetValue(() => SysDateTimeImport, value);
        }

        /// <summary>
        ///     Contain date when TN has been tracked last time
        /// </summary>
        public DateTime? SysDateTimeTrack
        {
            get => GetValue(() => SysDateTimeTrack);
            set => SetValue(() => SysDateTimeTrack, value);
        }

        /// <summary>
        ///     Contain deadline date when package should be delivered
        /// </summary>
        public DateTime? SysDateTimeSchedule
        {
            get => GetValue(() => SysDateTimeSchedule);
            set => SetValue(() => SysDateTimeSchedule, value);
        }

        /// <summary>
        ///     Contain date when Refund Request has been made
        /// </summary>
        public DateTime? SysDateTimeRefundRequest
        {
            get => GetValue(() => SysDateTimeRefundRequest);
            set => SetValue(() => SysDateTimeRefundRequest, value);
        }

        /// <summary>
        ///     Last technical error, if any
        /// </summary>
        [MaxLength(250)]
        public string? ErrorMessage
        {
            get => GetValue(() => ErrorMessage);
            set => SetValue(() => ErrorMessage, value);
        }

        /// <summary>
        ///     To be moved into different Table
        /// </summary>
        public string? TNTrackHTML
        {
            get => GetValue(() => TNTrackHTML);
            set => SetValue(() => TNTrackHTML, value);
        }

        /// <summary>
        ///     To be moved into different Table
        /// </summary>
        public string? TNTrackXML
        {
            get => GetValue(() => TNTrackXML);
            set => SetValue(() => TNTrackXML, value);
        }

        /// <summary>
        ///     To be moved into different Table
        /// </summary>
        public string? TNScheduleXML
        {
            get => GetValue(() => TNScheduleXML);
            set => SetValue(() => TNScheduleXML, value);
        }
    }
}
