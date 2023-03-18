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
        public void readFile(string path)
        {
            byte[] file = File.ReadAllBytes(path);

            for (int i=0; i<= file.Length; i++)
            {
                // CAT
                int cat = file[i];

                // LENGTH
                byte[] length_Bytes = { file[i + 2], file[i + 1] }; // order changed because we have 'big endian' and the function is 'little endian'
                int length = BitConverter.ToInt16(length_Bytes, 0);

                // Save message in corresponding list
                if (cat == 10)
                {
                    byte[] cat10data = file.Skip(i+3).Take(length).ToArray(); // maybe there is a better way to do this?
                    CAT10 data = new CAT10(cat10data);
                    listCAT10.Add(data);
                }
                if (cat == 21)
                {
                    byte[] cat21data = file.Skip(i + 3).Take(length).ToArray(); // maybe there is a better way to do this?
                    CAT21 data = new CAT21(cat21data);
                    listCAT21.Add(data);
                }
                i = i + 3 + length;
            }            
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
