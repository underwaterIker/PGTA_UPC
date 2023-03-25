using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Policy;

namespace ClassLibrary
{
    public class Functions
    {
        List<CAT10> listCAT10 = new List<CAT10>();
        List<CAT21> listCAT21 = new List<CAT21>();

        // READ FILE
        public string[] readFile(string path)
        {
            byte[] file_byte = File.ReadAllBytes(path);
            string[] file_string = file_byte.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray(); // maybe there is a FASTER way to do this

            for (int i=0; i < file_string.Length; )
            {
                // CAT
                int cat = file_byte[i];

                // LENGTH
                byte[] length_Bytes = { file_byte[i + 2], file_byte[i + 1] }; // order changed because we have 'big endian' and the function is 'little endian'
                int length = BitConverter.ToInt16(length_Bytes, 0);

                // Save message in corresponding list
                if (cat == 10)
                {
                    string[] cat10data = file_string.Skip(i+3).Take(length-3).ToArray(); // maybe there is a better way to do this?
                    CAT10 data = new CAT10(cat10data);
                    listCAT10.Add(data);
                }
                if (cat == 21)
                {
                    string[] cat21data = file_string.Skip(i + 3).Take(length-3).ToArray(); // maybe there is a better way to do this?
                    CAT21 data = new CAT21(cat21data);
                    listCAT21.Add(data);
                }
                i = i + length;
            }
            return file_string;
        }

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
