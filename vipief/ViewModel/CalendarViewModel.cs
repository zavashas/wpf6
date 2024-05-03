using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using vipief.ViewModel.Helpers;
using vipief.ViewModel;
using System.Collections.ObjectModel;

namespace vipief.ViewModel
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        private DateTime _selectedDate;
        private ObservableCollection<DateTime> _daysOfMonth;
        private ObservableCollection<string> _iconPaths;

        public event EventHandler SelectedDateChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public CalendarViewModel()
        {
            PreviousMonthCommand = new RelayCommand(PreviousMonth);
            NextMonthCommand = new RelayCommand(NextMonth);
            SelectedDate = DateTime.Now;
        }
        public void SelectDate(DateTime selectedDate)
        {
            SelectedDate = selectedDate;
        }

        public ICommand PreviousMonthCommand { get; private set; }
        public ICommand NextMonthCommand { get; private set; }

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                    OnPropertyChanged(nameof(CurrentMonth));
                    LoadDaysOfMonth();
                }
            }
        }
        public class DayOfMonthViewModel
        {
            public int Day { get; set; }
        }

        public string CurrentMonth => SelectedDate.ToString("MMMM yyyy");

        public ObservableCollection<DateTime> DaysOfMonth
        {
            get { return _daysOfMonth; }
            set
            {
                _daysOfMonth = value;
                OnPropertyChanged(nameof(DaysOfMonth));
            }
        }

        public ObservableCollection<string> IconPaths
        {
            get { return _iconPaths; }
            set
            {
                _iconPaths = value;
                OnPropertyChanged(nameof(IconPaths));
            }
        }

        private void LoadDaysOfMonth()
        {
            int year = SelectedDate.Year;
            int month = SelectedDate.Month;
            int daysInMonth = DateTime.DaysInMonth(year, month);
            DateTime firstDayOfMonth = new DateTime(year, month, 1);

            DaysOfMonth = new ObservableCollection<DateTime>(
                Enumerable.Range(1, daysInMonth) 
                .Select(day => new DateTime(year, month, day)));

            IconPaths = new ObservableCollection<string>(
                Enumerable.Repeat(@"\Images\comp.png", daysInMonth)); 


        }

        private void PreviousMonth(object obj)
        {
            SelectedDate = SelectedDate.AddMonths(-1);
        }

        private void NextMonth(object obj)
        {
            SelectedDate = SelectedDate.AddMonths(1);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName == nameof(SelectedDate))
            {
                SelectedDateChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}