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
    public partial class MenuPage : Page
    {
        public UserChoose choose;
        public MenuPage(UserChoose choose)
        {
            InitializeComponent();
            DataContext = new MenuViewModel();

            this.choose = choose;
            foreach (string option in UserChoose.options)
            {
                listBox.Items.Add(new DisciplineControl(option, choose.items.Contains(option)));
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CalendarPage());
        }
    }   
}
