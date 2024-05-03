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

        public DateOnly date { get; private set; }
        public List<string> items { get; } = new List<string>();

        // Метод для обновления выбора пользователя
        public void UpdateSelection(string option, bool isChecked)
        {
            if (isChecked)
            {
                if (!items.Contains(option))
                {
                    items.Add(option);
                }
            }
            else
            {
                items.Remove(option);
            }
        }
    }
}