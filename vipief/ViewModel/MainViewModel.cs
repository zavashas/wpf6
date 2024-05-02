using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using vipief.Model;
using vipief.ViewModel.Helpers;

namespace vipief.ViewModel
{
    internal class MainViewModel : BindingHelper
    {
        #region Свойства

        private Discipline selected;
        public Discipline Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged();
            }   
        }

        private ObservableCollection<Discipline> disciplines;
        public ObservableCollection<Discipline> Disciplines
        {
            get { return disciplines; }
            set
            {
                disciplines = value;
                OnPropertyChanged();
            }
        }

        
        #endregion

        public MainViewModel()
        {
            
            
        }
    }
}
