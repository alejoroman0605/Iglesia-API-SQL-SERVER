using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Common
{
    public class Util
    {
        public static int GetAge(DateTime dateOfBirth) {
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - dateOfBirth.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (dateOfBirth.Date > today.AddYears(-age))
                age--;
            return age;
        }

        
    }
}
