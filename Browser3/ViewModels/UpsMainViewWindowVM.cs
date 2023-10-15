using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
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
using LiveCharts;

namespace Browser3.ViewModels
{
    public class UpsMainViewWindowVM
    {
        #region Command definition
        public ICommand? RefreshCommand { get; set; }
        #endregion Command definition

        public UpsMainViewModel Model
        {
            get; set;
        } = new UpsMainViewModel();

        private const string CONST_YYYYMMDD = "yyyy-MM-dd";

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

            Model.ListOfCompany = AppData.DbMSSQL.RunExecStatement<CommonIdValueObject>("SELECT distinct TOP (1000) [ID], [CompanyTitle] as [Name] FROM [dbo].[Company] order by [Name];");
            Model.ListOfSubCompany = AppData.DbMSSQL.RunExecStatement<CommonIdValueObject>("SELECT distinct TOP (1000) [TNSubCompany] as [Name] FROM [dbo].[TNs] order by [Name];");
            Model.ListOfAccounts = AppData.DbMSSQL.RunExecStatement<CommonIdValueObject>("SELECT distinct TOP (1000) [TNAccountID] as [Name] FROM [dbo].[TNs] where [TNAccountID] is Not null order by [Name];");

            Reload();
        }

        private void InitCommands()
        {
            RefreshCommand = new RelayCommand(RefreshCommandProc);
        }

        private void RefreshCommandProc(object obj)
        {
            Reload();
        }

        private string BuildWhereCondition()
        {
            string result = string.Empty;
            string? value = string.Empty;

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
                value = Model.StartRange?.ToString(CONST_YYYYMMDD);
                result += $"(TNShippedDate >= '{value}')";
            }

            if (Model.EndRange != null)
            {
                if (!String.IsNullOrEmpty(result))
                {
                    result += " and ";
                }
                value = Model.EndRange?.ToString(CONST_YYYYMMDD);
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

            string queryTemplateCount =
                "select count(*) as TOTAL_COUNT " +
                "from [dbo].[TNs] " +
                "{0};";

            string query = String.Format(queryTemplate, top, tnWhere);
            string queryCount = String.Format(queryTemplateCount, tnWhere);

            //

            Model.TNs = AppData.DbMSSQL.RunExecStatement<TNBaseEx>(query);
            int result = AppData.DbMSSQL.RunNonExecStatementEx(queryCount);

            Model.TotalCount = result;
            Model.TotalCountAfterFilter = Model.TNs.Count;
            Model.TotalCountAfterAddonFilter = 0;
        }
    }
}
