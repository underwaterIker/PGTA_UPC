using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CAT10
    {
        public string HexToBinary(string hexadecimal)
        {
            string binary = Convert.ToString(Convert.ToInt32(hexadecimal, 16), 2).PadLeft(hexadecimal.Length*4, '0');
            return binary;
        }
    }
}
