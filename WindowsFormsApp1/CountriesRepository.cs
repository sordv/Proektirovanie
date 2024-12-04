using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace WindowsFormsApp1
{
    internal class CountriesRepository
    {
        public List<string> GetCountries()
        {
            return new List<string>
            {
                "Азербайджан",
                "Кыргызстан",
                "Молдова",
                "Таджикистан",
                "Украина",
                "Другая страна"
            };
        }
    }
}
