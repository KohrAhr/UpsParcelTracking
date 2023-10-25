using System;
using System.Windows;
using System.Windows.Controls;
using Browser3.Functions;
using CommunityToolkit.Mvvm.Input;

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

//            DataContext = new DateSelectorBarVM();
        }

        #region Commands definition and implementation
        private void SetCommonDays(int aDays)
        {
            SelectedStartDate = DateTimeFunctions.GetDayMinusDays(DateTime.Today, aDays);
            SelectedEndDate = DateTime.Today;
        }

        [RelayCommand]
        void SelectDateRangeCurrentMonthProc()
        {
            SelectedStartDate = DateTimeFunctions.GetFirstDayOfMonth(DateTime.Today);
            SelectedEndDate = DateTimeFunctions.GetLastDayOfMonth(DateTime.Today);
        }

        [RelayCommand]
        void SelectDateRangeCurrentYearProc()
        {
            SelectedStartDate = DateTimeFunctions.GetFirstDayOfYear(DateTime.Today);
            SelectedEndDate = DateTimeFunctions.GetLastDayOfYear(DateTime.Today);
        }

        [RelayCommand]
        void SelectDateRangeCurrentWeekProc()
        {
            SelectedStartDate = DateTimeFunctions.GetFirstDayOfWeek(DateTime.Today);
            SelectedEndDate = DateTimeFunctions.GetLastDayOfWeek(DateTime.Today);
        }

        [RelayCommand]
        void SelectDateRangeLast15DaysProc()
        {
            SetCommonDays(15);
        }

        [RelayCommand]
        void SelectDateRangeLast30DaysProc()
        {
            SetCommonDays(30);
        }

        [RelayCommand]
        void SelectDateRangeLast45DaysProc()
        {
            SetCommonDays(45);
        }

        [RelayCommand]
        void SelectDateRangeLast60DaysProc()
        {
            SetCommonDays(60);
        }

        [RelayCommand]
        void SelectDateRangeLast90DaysProc()
        {
            SetCommonDays(90);
        }

        [RelayCommand]
        void SelectDateRangeLast180DaysProc()
        {
            SetCommonDays(180);
        }

        [RelayCommand]
        void SelectDateRangeLast365DaysProc()
        {
            SetCommonDays(365);
        }

        [RelayCommand]
        void SelectDateRangeOver1YearProc()
        {
            SelectedStartDate = null;
            SelectedEndDate = DateTimeFunctions.GetDayMinusDays(DateTime.Today, 365);
        }

        [RelayCommand]
        void SelectDateRangeNoneProc()
        {
            SelectedStartDate = null;
            SelectedEndDate = null;
        }
        #endregion Commands definition and implementation
    }
}
