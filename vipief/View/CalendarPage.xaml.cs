using MaterialDesignThemes.Wpf;
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
using vipief.cards;
using vipief.Model;
using vipief.ViewModel;

namespace vipief.View
{
    public partial class CalendarPage : Page
    {
        public CalendarPage()
        {
            InitializeComponent();
            DataContext = new CalendarViewModel();

        }
        private void DaySquareControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
                UserChoose choose = new UserChoose(currentDate);
                this.NavigationService.Navigate(new MenuPage(choose));
            }
            else if (e.ChangedButton == MouseButton.Right)
            {
                ContextMenu contextMenu = this.ContextMenu;
                if (contextMenu != null)
                {
                    contextMenu.PlacementTarget = this;
                    contextMenu.IsOpen = true;
                }
            }
        }


    }
}
