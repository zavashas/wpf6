using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace vipief.Model
{
    public class Discipline
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public bool IsSelected { get; set; }
        public DateTime dateTime { get; set; }  


        public Discipline(string name, string iconpath, DateTime choosedate, bool isSelected)
        {
            Name = name;
            ImagePath = iconpath;
            dateTime = choosedate;
            IsSelected = isSelected;          
        }
    }
}
