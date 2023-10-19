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
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using System.Net;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using Lib.UI.Net6;
using System.Collections;

namespace Browser3.ViewModels
{
    public class UpsMain3DViewWindowVM
    {
        #region Command definition
        public ICommand? RefreshCommand { get; set; }

        public ICommand? DrillDownView2Command { get; set; }
        #endregion Command definition

        public UpsMain3DViewModel Model
        {
            get; set;
        } = new UpsMain3DViewModel();

        public UpsMain3DViewWindowVM()
        {
            InitData();
            InitCommands();
        }

        private void InitData()
        {
            Model.ListOfCommonPhrases = CoreClassification.CommonPhrases;

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

        private void InitCommands()
        {
            RefreshCommand = new RelayCommand(RefreshCommandProc);

            DrillDownView2Command = new RelayCommand(DrillDownView2CommandProc);
        }

        private void DrillDownView2CommandProc(object obj)
        {
            if (obj is ChartPoint point)
            {
                CommonDialogs.ShowInfoMessage("Chart", point.SeriesView.Title);
            }
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

            // Final
            if (!String.IsNullOrEmpty(result))
            {
                result = $" where {result}";
            }

            return result;
        }

        private void Reload()
        {
            // Build where
            string tnWhere = BuildWhereCondition();
            
            string queryTemplateView1 =
                "SELECT TNShippingStatus AS ID, COUNT(TNTrackingNumber) AS ResultValue " +
                "FROM dbo.TNs " +
                "{0} " +
                "GROUP BY TNShippingStatus " +
                "ORDER BY ID;";

            string queryTemplateView2 =
                "SELECT LateStatus AS ID, COUNT(TNTrackingNumber) AS ResultValue " +
                "FROM dbo.TNs " +
                "{0} " +
                "GROUP BY LateStatus " +
                "ORDER BY LateStatus;";

            string query1 = String.Format(queryTemplateView1, tnWhere);
            string query2 = String.Format(queryTemplateView2, tnWhere);
            string queryCount = String.Format(CoreQueriers.CONST_TN_COUNT_TEMPLATE, tnWhere);

            // <lvc:PieChart.Series>

            Model.TNs3D = new SeriesCollection();
            Model.TNs3DView2 = new SeriesCollection();

            // Main view 1
            // Exec query with cache
            Model.TNs = AppData.DbMSSQL.ConvertDataTableToObservableCollection<IdValueCommon>
            (
                CoreCache.GetDataFromCacheOrDatabase<DataTable>(query1)
            );

            // Exec query with cache
            Model.TNsView2 = AppData.DbMSSQL.ConvertDataTableToObservableCollection<IdValueCommon>
            (
                CoreCache.GetDataFromCacheOrDatabase<DataTable>(query2)
            );

            //Model.TNs = AppData.DbMSSQL.RunExecStatement<IdValueCommon>(query1);
            //Model.TNsView2 = AppData.DbMSSQL.RunExecStatement<IdValueCommon>(query2);

            // Data for View 1
            foreach (IdValueCommon item in Model.TNs)
            {
                double value;

                if (Double.TryParse(item.ResultValue, out value))
                {
                    // 
                    string title = "N/A";
                    if (item.ID != null)
                    {
                        CommonIdValueObject? commonIdValueObject = CoreClassification.ShippingStatus.FirstOrDefault(x => x.ID == item.ID);
                        if (commonIdValueObject != null)
                        {
                            title = commonIdValueObject.Name;
                        }

                        if (String.IsNullOrEmpty(title))
                        {
                            title = "NEW ENTRY or UNRESOLVED";
                        }
                    }

                    PieSeries pieSeries = new PieSeries
                    {
                        Title = title,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(value) },
                        DataLabels = true
                    };

                    Model.TNs3D.Add(pieSeries);
                }
            }

            // Data for View 2
            foreach (IdValueCommon item in Model.TNsView2)
            {
                double value;

                if (Double.TryParse(item.ResultValue, out value))
                {
                    // 
                    string title = "N/A";
                    if (item.ID != null)
                    {
                        CommonIdValueObject? commonIdValueObject = CoreClassification.LateStatus.FirstOrDefault(x => x.ID == item.ID);
                        if (commonIdValueObject != null)
                        {
                            title = commonIdValueObject.Name;
                        }

                        if (String.IsNullOrEmpty(title))
                        {
                            title = "OTHER or NOT LATE";
                        }
                    }

                    PieSeries pieSeries = new PieSeries
                    {
                        Title = title,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(value) },
                        DataLabels = true
                    };

                    Model.TNs3DView2.Add(pieSeries);
                }
            }

            // Total Count
            int result = CoreCache.GetDataFromCacheOrDatabase<int>(queryCount);

            Model.TotalCount = result;
        }

    }
}
