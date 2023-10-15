using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Browser3.Core;
using Browser3.Functions;
using Browser3.Models;
using Browser3.Types;
using Dapper;
using Lib.MVVM.Net6;
using Lib.UI.Net6;


namespace Browser3.ViewModels
{
    public class UpsMainViewWindowVM
    {
        #region Command definition
        public ICommand? RefreshCommand { get; set; }
        public ICommand? CopyToClipboardTNCommand { get; set; }
        public ICommand? CopyToClipboardCompanyNameCommand { get; set; }
        public ICommand? CopyToClipboardSubCompanyNameCommand { get; set; }
        public ICommand? CopyToClipboardAccountIdCommand { get; set; }
        public ICommand? CopyToClipboardAllVisibleTNsCommand { get; set; }
        #endregion Command definition

        public UpsMainViewModel Model
        {
            get; set;
        } = new UpsMainViewModel();

        public UpsMainViewWindowVM()
        {
            InitData();

            InitCommands();
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
                CoreCache.GetDataFromCacheOrDatabase("CONST_SIMPLE_LIST_OF_COMPANY", CoreQueriers.CONST_SIMPLE_LIST_OF_COMPANY)
            );

            Model.ListOfCompany = AppData.DbMSSQL.ConvertDataTableToObservableCollection<CommonIdValueObject>
            (
                CoreCache.GetDataFromCacheOrDatabase("CONST_SIMPLE_LIST_OF_SUBCOMPANY", CoreQueriers.CONST_SIMPLE_LIST_OF_SUBCOMPANY)
            );

            Model.ListOfCompany = AppData.DbMSSQL.ConvertDataTableToObservableCollection<CommonIdValueObject>
            (
                CoreCache.GetDataFromCacheOrDatabase("CONST_SIMPLE_LIST_OF_ACCOUNTS", CoreQueriers.CONST_SIMPLE_LIST_OF_ACCOUNTS)
            );

            Reload();
        }

        private void InitCommands()
        {
            RefreshCommand = new RelayCommand(RefreshCommandProc);
            CopyToClipboardTNCommand = new RelayCommand(CopyToClipboardTNCommandProc);
            CopyToClipboardCompanyNameCommand = new RelayCommand(CopyToClipboardCompanyNameCommandProc);
            CopyToClipboardSubCompanyNameCommand = new RelayCommand(CopyToClipboardSubCompanyNameCommandProc);
            CopyToClipboardAccountIdCommand = new RelayCommand(CopyToClipboardAccountIdCommandProc);
            CopyToClipboardAllVisibleTNsCommand = new RelayCommand(CopyToClipboardAllVisibleTNsCommandProc);
        }

        private void CopyToClipboardAllVisibleTNsCommandProc(object obj)
        {
            throw new NotImplementedException();
        }

        private void CopyToClipboardAccountIdCommandProc(object obj)
        {
            ClipboardFunctions.CopyValueToClipboard<TNBaseEx>(Model.SelectedItem, "TNAccountID");
        }

        private void CopyToClipboardSubCompanyNameCommandProc(object obj)
        {
            ClipboardFunctions.CopyValueToClipboard<TNBaseEx>(Model.SelectedItem, "TNSubCompany");
        }

        private void CopyToClipboardCompanyNameCommandProc(object obj)
        {
            ClipboardFunctions.CopyValueToClipboard<TNBaseEx>(Model.SelectedItem, "CompanyTitle");
        }

        private void CopyToClipboardTNCommandProc(object obj)
        {
            ClipboardFunctions.CopyValueToClipboard<TNBaseEx>(Model.SelectedItem, "TNTrackingNumber");
        }

        private void RefreshCommandProc(object obj)
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

            //

            Model.TNs = AppData.DbMSSQL.RunExecStatement<TNBaseEx>(query);
            int result = AppData.DbMSSQL.RunNonExecStatementEx(queryCount);

            Model.TotalCount = result;
            Model.TotalCountAfterFilter = Model.TNs.Count;
            Model.TotalCountAfterAddonFilter = 0;
        }
    }
}
