using System;
using System.Data;
using System.Windows.Input;
using Browser3.Core;
using Browser3.Functions;
using Browser3.Models;
using Browser3.Types;
using Lib.UI.Net6;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Browser3.ViewModels
{
    public partial class UpsMainViewWindowVM : ObservableObject
    {
        public UpsMainViewModel Model
        {
            get; set;
        } = new UpsMainViewModel();

        public UpsMainViewWindowVM()
        {
            InitData();
        }

        private void InitData()
        {
            Model.ShowTop = CoreClassification.ShowTop;
            Model.SelectedShowTop = "500";
            Model.ListOfCommonPhrases = CoreClassification.CommonPhrases;
            Model.ListOfShippingStatuses = CoreClassification.ShippingStatus;
            Model.ListOfLateStatuses = CoreClassification.LateStatus;

            Model.ListOfCompany = AppData.DbMSSQL.ConvertDataTableToObservableCollection<CommonIdValueObject>
            (
                CoreCache.GetDataFromCacheOrDatabase<DataTable>(CoreQueriers.CONST_SIMPLE_LIST_OF_COMPANY, "CONST_SIMPLE_LIST_OF_COMPANY")
            );

            Model.ListOfSubCompany = AppData.DbMSSQL.ConvertDataTableToObservableCollection<CommonIdValueObject>
            (
                CoreCache.GetDataFromCacheOrDatabase<DataTable>(CoreQueriers.CONST_SIMPLE_LIST_OF_SUBCOMPANY, "CONST_SIMPLE_LIST_OF_SUBCOMPANY")
            );

            Model.ListOfAccounts = AppData.DbMSSQL.ConvertDataTableToObservableCollection<CommonIdValueObject>
            (
                CoreCache.GetDataFromCacheOrDatabase<DataTable>(CoreQueriers.CONST_SIMPLE_LIST_OF_ACCOUNTS, "CONST_SIMPLE_LIST_OF_ACCOUNTS")
            );

            Reload();
        }

        [RelayCommand]
        void CopyToClipboardAllVisibleTNsProc()
        {
            throw new NotImplementedException();
        }

        [RelayCommand]
        void CopyToClipboardAccountIdProc()
        {
            if (Model.SelectedItem == null)
            {
                return;
            }
            ClipboardFunctions.CopyValueToClipboard<TNBaseEx>(Model.SelectedItem, "TNAccountID");
        }

        [RelayCommand]
        void CopyToClipboardSubCompanyNameProc()
        {
            if (Model.SelectedItem == null)
            {
                return;
            }
            ClipboardFunctions.CopyValueToClipboard<TNBaseEx>(Model.SelectedItem, "TNSubCompany");
        }

        [RelayCommand]
        void CopyToClipboardCompanyNameProc()
        {
            if (Model.SelectedItem == null)
            {
                return;
            }
            ClipboardFunctions.CopyValueToClipboard<TNBaseEx>(Model.SelectedItem, "CompanyTitle");
        }

        [RelayCommand]
        void CopyToClipboardTNProc()
        {
            if (Model.SelectedItem == null)
            {
                return;
            }
            ClipboardFunctions.CopyValueToClipboard<TNBaseEx>(Model.SelectedItem, "TNTrackingNumber");
        }

        [RelayCommand]
        void RefreshProc()
        { 
            Reload(); 
        }

        private string BuildWhereCondition()
        {
            string result = string.Empty;
            string? value;

            // #1

            int? intValue = Model.SelectedCompanyID;

            if (intValue != null && intValue != 0)
            {
                result += $" (TNCompanyID = {intValue}) ";
            }

            // #2

            value = Model.SelectedSubCompany;

            if (!String.IsNullOrEmpty(value))
            {
                if (!String.IsNullOrEmpty(result))
                {
                    result += " and ";
                }
                result += $" (TNSubCompany like '%{value}%') ";
            }

            // #2

            value = Model.SelectedAccount;

            if (!String.IsNullOrEmpty(value))
            {
                if (!String.IsNullOrEmpty(result))
                {
                    result += " and ";
                }
                result += $" (TNAccountID like '%{value}%') ";
            }

            // #3

            value = Model.SelectedTN;

            if (!String.IsNullOrEmpty(value))
            {
                if (!String.IsNullOrEmpty(result))
                {
                    result += " and ";
                }
                result += $" (TNTrackingNumber like '%{value}%') ";
            }

            // #4

            value = Model.SelectedCommonPhrase;

            if (!String.IsNullOrEmpty(value))
            {
                if (!String.IsNullOrEmpty(result))
                {
                    result += " and ";
                }
                result += $" (TNTrackHTML like '%{value}%') ";
            }

            // DateRange. Applicable for: Shipped From Till

            if (Model.StartRange != null)
            {
                if (!String.IsNullOrEmpty(result))
                {
                    result += " and ";
                }
                value = Model.StartRange?.ToString(CoreConstants.CONST_DB_DATE_FORMAT);
                result += $"(TNShippedDate >= '{value}')";
            }

            if (Model.EndRange != null)
            {
                if (!String.IsNullOrEmpty(result))
                {
                    result += " and ";
                }
                value = Model.EndRange?.ToString(CoreConstants.CONST_DB_DATE_FORMAT);
                result += $"(TNShippedDate <= '{value}')";
            }

            // Shipping status & Late status

            intValue = Model.SelectedShippingStatus;

            if (intValue != null && intValue != 0)
            {
                if (!String.IsNullOrEmpty(result))
                {
                    result += " and ";
                }
                result += $" (TNShippingStatus = {intValue}) ";
            }

            intValue = Model.SelectedLateStatus;

            if (intValue != null && intValue != 0)
            {
                if (!String.IsNullOrEmpty(result))
                {
                    result += " and ";
                }
                result += $" (LateStatus = {intValue}) ";
            }

            // Final
            if (!String.IsNullOrEmpty(result))
            {
                result = $" where {result}";
            }

            return result;
        }

        private string BuildShowTopCondition()
        {
            string result = string.Empty;
            string value = Model.SelectedShowTop;

            if (!String.IsNullOrEmpty(value)) 
            {
                result = $" TOP {value} ";
            }

            return result;
        }

        private void Reload()
        {
            // Build where
            string tnWhere = BuildWhereCondition();
            string top = BuildShowTopCondition();

            string queryTemplate =
                "select {0} " +
                "[TNID], [TNCompanyID], [TNSubCompany], [TNAccountID], [TNTrackingNumber], [TNService], [TNWeightLbs], [TNShipToCity], [TNShipToState], [TNShipToZIP], [TNShipToCountry], [TNShipFromCity], [TNShipFromState], [TNShipFromZIP], [TNShipFromCountry], " +
                "[TNShippingStatus], " +
                "[TNShippedDate], [TNScheduledDate], [TNDeliveredDate], " +
                "[SysIsChecked], [SysStatus], [LateStatus], [RRSStatus], [SysDateTimeImport], [SysDateTimeTrack], [SysDateTimeSchedule], [SysDateTimeRefundRequest], [ErrorMessage], [TNTrackHTML], [CompanyTitle] " +
                "from [dbo].[TNs] " +
                "LEFT OUTER JOIN [dbo].[Company] ON [dbo].[TNs].[TNCompanyID] = [dbo].[Company].[ID] " +
                "{1};";

            string query = String.Format(queryTemplate, top, tnWhere);
            string queryCount = String.Format(CoreQueriers.CONST_TN_COUNT_TEMPLATE, tnWhere);

            using (var waitCursor = new WaitCursor(Cursors.Wait))
            {
                Model.TNs = AppData.DbMSSQL.ConvertDataTableToObservableCollection<TNBaseEx>
                (
                    CoreCache.GetDataFromCacheOrDatabase<DataTable>(query)
                );
            }

            int result = CoreCache.GetDataFromCacheOrDatabase<int>(queryCount);

            Model.TotalCount = result;
            Model.TotalCountAfterFilter = Model.TNs.Count;
            Model.TotalCountAfterAddonFilter = 0;
        }
    }
}
