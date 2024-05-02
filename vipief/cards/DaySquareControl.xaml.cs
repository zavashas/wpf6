using System;
using System.Collections.Generic;
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
using vipief.View;

namespace vipief.cards
{
    public partial class DaySquareControl : UserControl
    {
        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("Date", typeof(DateTime), typeof(DaySquareControl), new PropertyMetadata(DateTime.Now));

        public static readonly DependencyProperty DayOfMonthProperty =
            DependencyProperty.Register("DayOfMonth", typeof(int), typeof(DaySquareControl), new PropertyMetadata(1, OnDayOfMonthChanged));

        public static readonly DependencyProperty IconPathProperty =
            DependencyProperty.Register("IconPath", typeof(string), typeof(DaySquareControl), new PropertyMetadata(string.Empty));

        public DateTime Date
        {
            get { return (DateTime)GetValue(DateProperty); }
            set { SetValue(DateProperty, value.Date); }
        }

        public int DayOfMonth
        {
            get { return (int)GetValue(DayOfMonthProperty); }
            set { SetValue(DayOfMonthProperty, value); }
        }

        public string IconPath
        {
            get { return (string)GetValue(IconPathProperty); }
            set { SetValue(IconPathProperty, value); }
        }

        public DaySquareControl()
        {
            InitializeComponent();
        }

        private static void OnDayOfMonthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (DaySquareControl)d;
            int year = control.Date.Year;
            int month = control.Date.Month;
            int day = (int)e.NewValue;

            if (day >= 1 && day <= DateTime.DaysInMonth(year, month))
            {
                control.Date = new DateTime(year, month, day);
            }
            else
            {
                control.Date = new DateTime(year, month, 1);
            }
        }

       
    }
}
