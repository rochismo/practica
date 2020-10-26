using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EjerciciosInnovation
{
    public class Util
    {
        private static Regex NUMBER_REGEX = new Regex(@"^\d*$");
        public static bool isNumber(string value)
        {
            return NUMBER_REGEX.IsMatch(value);
        }

        
    }
}
