using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    class stringToInt
    {
        string stringNumber;

        public stringToInt(string stringNumber)
        {
            this.stringNumber = stringNumber;
        }

        public int StringToInt()
        {
            if(!stringNumber.All(c => Char.IsDigit(c)))
            {
                throw new ArgumentException("Cant convert to int");
            }

            var digits = stringNumber.Select(c => (int)c - 48);

            int number = 0;
            foreach (int digit in digits)
            {
                number = number * 10 + digit;
            }

            return number;
        }
    }
}
