using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using vipief.Model;
using vipief.ViewModel.Helpers;
using System.Xml.Serialization;
using vipief.cards;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace vipief.ViewModel
{
    internal class MenuViewModel : BindingHelper
    {
        public ICommand SaveAndExitCommand { get; private set; }

        private UserChoose _userChoose;

        public MenuViewModel()
        {
            SaveAndExitCommand = new RelayCommand(param => SaveAndExit());

            _userChoose = Saves.LoadUserChoose(DateOnly.FromDateTime(DateTime.Now));

            foreach (var control in Controls)
            {
                control.CheckBoxStateChanged += OnCheckBoxStateChanged;
            }
        }

        public ObservableCollection<DisciplineControl> Controls { get; } = new ObservableCollection<DisciplineControl>();

        private void OnCheckBoxStateChanged(object sender, bool isChecked)
        {
            if (sender is DisciplineControl control)
            {

                _userChoose.UpdateSelection(control.name, isChecked);

 
                Saves.SaveUserChoose(_userChoose);
            }
        }
        private void SaveAndExit()
        {
            Saves.SaveUserChoose(_userChoose);
        }
    }
}