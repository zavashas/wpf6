using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vipief.Model
{
        public class UserChoose
         {
        public readonly static string[] options =
       {
             "C++", "Java", "JS", "Linux", "Python", "бд"
        };

        public UserChoose(DateOnly date)
        {
            this.date = date;
        }

        public DateOnly date { get; init; }
        public List<string> items = new();
    }
}
