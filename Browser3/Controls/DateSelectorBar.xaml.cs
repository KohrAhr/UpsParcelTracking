using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Browser3.Functions;
using Lib.MVVM.Net6;

namespace Browser3.Controls
{
    /// <summary>
    /// Interaction logic for DateSelectorBar.xaml
    /// </summary>
    public partial class DateSelectorBar : UserControl
    {
        public static readonly DependencyProperty SelectedStartDateProperty = DependencyProperty.Register
        (
            "SelectedStartDate",
            typeof(DateTime?),
            typeof(DateSelectorBar),
            new PropertyMetadata(null)
        );

        public static readonly DependencyProperty SelectedEndDateProperty = DependencyProperty.Register
        (
            "SelectedEndDate",
            typeof(DateTime?),
            typeof(DateSelectorBar),
            new PropertyMetadata(null)
        );

        public DateTime? SelectedStartDate
        {
            get
            {
                return (DateTime?)GetValue(SelectedStartDateProperty);
            }
            set
            {
                SetValue(SelectedStartDateProperty, value);
            }
        }

        public DateTime? SelectedEndDate
        {
            get
            {
                return (DateTime?)GetValue(SelectedEndDateProperty);
            }
            set
            {
                SetValue(SelectedEndDateProperty, value);
            }
        }

        public DateSelectorBar()
        {
            InitializeComponent();
        }

        #region Commands definition and implementation
        private void SetCommonDays(int aDays)
        {
            SelectedStartDate = DateTimeFunctions.GetDayMinusDays(DateTime.Today, aDays);
            SelectedEndDate = DateTime.Today;
        }

        private RelayCommand? selectDateRangeCurrentMonth;
        public ICommand SelectDateRangeCurrentMonth => selectDateRangeCurrentMonth ??= new RelayCommand(PerformSelectDateRangeCurrentMonth);

        private void PerformSelectDateRangeCurrentMonth(object commandParameter)
        {
            SelectedStartDate = DateTimeFunctions.GetFirstDayOfMonth(DateTime.Today);
            SelectedEndDate = DateTimeFunctions.GetLastDayOfMonth(DateTime.Today);
        }

        private RelayCommand? selectDateRangeCurrentYear;
        public ICommand SelectDateRangeCurrentYear => selectDateRangeCurrentYear ??= new RelayCommand(PerformSelectDateRangeCurrentYear);

        private void PerformSelectDateRangeCurrentYear(object commandParameter)
        {
            SelectedStartDate = DateTimeFunctions.GetFirstDayOfYear(DateTime.Today);
            SelectedEndDate = DateTimeFunctions.GetLastDayOfYear(DateTime.Today);
        }

        private RelayCommand? selectDateRangeCurrentWeek;
        public ICommand SelectDateRangeCurrentWeek => selectDateRangeCurrentWeek ??= new RelayCommand(PerformSelectDateRangeCurrentWeek);

        private void PerformSelectDateRangeCurrentWeek(object commandParameter)
        {
            SelectedStartDate = DateTimeFunctions.GetFirstDayOfWeek(DateTime.Today);
            SelectedEndDate = DateTimeFunctions.GetLastDayOfWeek(DateTime.Today);
        }

        private RelayCommand? selectDateRangeLast15Days;
        public ICommand SelectDateRangeLast15Days => selectDateRangeLast15Days ??= new RelayCommand(PerformSelectDateRangeLast15Days);

        private void PerformSelectDateRangeLast15Days(object commandParameter)
        {
            SetCommonDays(15);
        }

        private RelayCommand? selectDateRangeLast30Days;
        public ICommand SelectDateRangeLast30Days => selectDateRangeLast30Days ??= new RelayCommand(PerformSelectDateRangeLast30Days);

        private void PerformSelectDateRangeLast30Days(object commandParameter)
        {
            SetCommonDays(30);
        }

        private RelayCommand? selectDateRangeLast45Days;
        public ICommand SelectDateRangeLast45Days => selectDateRangeLast45Days ??= new RelayCommand(PerformSelectDateRangeLast45Days);

        private void PerformSelectDateRangeLast45Days(object commandParameter)
        {
            SetCommonDays(45);
        }

        private RelayCommand? selectDateRangeLast60Days;
        public ICommand SelectDateRangeLast60Days => selectDateRangeLast60Days ??= new RelayCommand(PerformSelectDateRangeLast60Days);

        private void PerformSelectDateRangeLast60Days(object commandParameter)
        {
            SetCommonDays(60);
        }

        private RelayCommand? selectDateRangeLast90Days;
        public ICommand SelectDateRangeLast90Days => selectDateRangeLast90Days ??= new RelayCommand(PerformSelectDateRangeLast90Days);

        private void PerformSelectDateRangeLast90Days(object commandParameter)
        {
            SetCommonDays(90);
        }

        private RelayCommand? selectDateRangeLast180Days;
        public ICommand SelectDateRangeLast180Days => selectDateRangeLast180Days ??= new RelayCommand(PerformSelectDateRangeLast180Days);

        private void PerformSelectDateRangeLast180Days(object commandParameter)
        {
            SetCommonDays(180);
        }

        private RelayCommand? selectDateRangeLast365Days;
        public ICommand SelectDateRangeLast365Days => selectDateRangeLast365Days ??= new RelayCommand(PerformSelectDateRangeLast365Days);

        private void PerformSelectDateRangeLast365Days(object commandParameter)
        {
            SetCommonDays(365);
        }

        private RelayCommand? selectDateRangeOver1Year;
        public ICommand SelectDateRangeOver1Year => selectDateRangeOver1Year ??= new RelayCommand(PerformSelectDateRangeOver1Year);

        private void PerformSelectDateRangeOver1Year(object commandParameter)
        {
            SelectedStartDate = null;
            SelectedEndDate = DateTimeFunctions.GetDayMinusDays(DateTime.Today, 365);
        }

        private RelayCommand? selectDateRangeNone;
        public ICommand SelectDateRangeNone => selectDateRangeNone ??= new RelayCommand(PerformSelectDateRangeNone);

        private void PerformSelectDateRangeNone(object commandParameter)
        {
            SelectedStartDate = null;
            SelectedEndDate = null;
        }
        #endregion Commands definition and implementation
    }
}
