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
        // READ FILE
        public static string[] readFile(string path)
        {
            List<CAT10> listCAT10 = new List<CAT10>();
            List<CAT21> listCAT21 = new List<CAT21>();

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

        // A2 Complement function
        public static int TwosComplement2Int(string str)
        {
            if (str[0] == '1')
            {
                // Ones complement done with str.replace()
                StringBuilder onesComplement = new StringBuilder(str);
                onesComplement = onesComplement.Replace('0', '2');
                onesComplement = onesComplement.Replace('1', '0');
                onesComplement = onesComplement.Replace('2', '1');

                // Twos complement
                StringBuilder twosComplement = onesComplement;
                for (int i = 0; i < twosComplement.Length; i++)
                {
                    int index = twosComplement.Length - i - 1;
                    if (twosComplement[index] == '1')
                    {
                        twosComplement.Remove(index, 1).Insert(index, "0");
                        //twosComplement[index] = '0';
                    }
                    else
                    {
                        twosComplement.Remove(index, 1).Insert(index, "1");
                        //twosComplement[index] = '1';
                        break;
                    }
                }
                return -Bin2Num(twosComplement.ToString());
            }
            else
            {
                return Bin2Num(str);
            }
        }

        // CONVERTER FUNCTIONS
        public static int Bin2Num(string bin)
        {
            return Convert.ToInt32(bin, 2);
        }

        public static string Bin2Hex(string bin)
        {
            return Convert.ToInt32(bin, 2).ToString("X");
            // this would not work with strings of more than 64 bits
        }

        public static string Hex2Bin(string hex)
        {
            string binary = Convert.ToString(Convert.ToInt32(hex, 16), 2).PadLeft(hex.Length * 4, '0');
            return binary;
        }

        // READ FILE CONVERTING HEX TO BIN
        public static string[] readFile_Hex2Bin(string[] fileHex)
        {
            
            string[] fileBin = new string[] {};
            //string[] fileBin = new string[100];
            for (int i = 0; i <= fileHex.Length; i++)
            {
                fileBin[i] = Hex2Bin(fileHex[i]);
            }
            return fileBin;
        }

        // CAT & LENGTH
        public static int cat(string cat)
        {
            int category = Bin2Num(cat);
            return category;
        }

        public static int length(string octet1, string octet2)
        {
            string octet12 = octet1 + octet2;
            int length = Bin2Num(octet12);
            return length;
        }

        // FSPEC

    }
}
