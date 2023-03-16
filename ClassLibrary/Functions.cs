using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class Functions
    {
        // CONVERTER FUNCTIONS
        public string HexToBinary(string hexadecimal)
        {
            string binary = Convert.ToString(Convert.ToInt32(hexadecimal, 16), 2).PadLeft(hexadecimal.Length * 4, '0');
            return binary;
        }

        public int BinToNum(string bin)
        {
            int number = Convert.ToInt32(bin, 2);
            return number;
        }

        // READ FILE CONVERTING HEX TO BIN
        public string[] readFile_HexToBin(string[] fileHex)
        {
            
            string[] fileBin = new string[] {};
            //string[] fileBin = new string[100];
            for (int i = 0; i <= fileHex.Length; i++)
            {
                fileBin[i] = HexToBinary(fileHex[i]);
            }
            return fileBin;
        }

        // CAT & LENGTH
        public int cat(string cat)
        {
            int category = BinToNum(cat);
            return category;
        }

        public int length(string octet1, string octet2)
        {
            string octet12 = octet1 + octet2;
            int length = BinToNum(octet12);
            return length;
        }

        // FSPEC

    }
}
