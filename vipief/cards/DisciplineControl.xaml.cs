using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using System.Xml.Linq;
using vipief.Model;

namespace vipief.cards
{
    public partial class DisciplineControl : UserControl
    {
        public event EventHandler<bool> CheckBoxStateChanged;

        public string name { get; init; }
        public bool isOn => checkbox.IsChecked ?? false;

        public DisciplineControl(string name, bool isOn)
        {
            InitializeComponent();

            this.name = name;
            string imagePath = "/Images/" + name + ".png";

            picture.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            DisciplineName.Content = name;
            checkbox.IsChecked = isOn;


            checkbox.Checked += (sender, e) => OnCheckBoxStateChanged(true);
            checkbox.Unchecked += (sender, e) => OnCheckBoxStateChanged(false);
        }

        private void OnCheckBoxStateChanged(bool isChecked)
        {
            CheckBoxStateChanged?.Invoke(this, isChecked);
        }
    }
}
