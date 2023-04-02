using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Policy;
using System.Collections;

namespace ClassLibrary
{
    public class Functions
    {
        // Combine n bytes to a number (bytes have to be already reversed)
        public static int CombineBytes2Int(byte[] bytes)
        {
            double combinedBytes = bytes[0];
            for (int i = 1; i < bytes.Length; i++)
            {
                combinedBytes += Math.Pow(2, 8 * i) * bytes[i];
            }
            return (int)combinedBytes;
        }

        // A2 Complement function from Bytes (bytes have to be already reversed)
        public static int TwosComplement2Int_fromBytes(byte[] bytes)
        {
            BitArray bits = new BitArray(bytes);

            if (bits[bits.Length-1] == true)
            {
                // Ones complement
                for (int i = 0; i < bits.Length; i++)
                {
                    bits[i] = !bits[i];
                }

                // Twos complement
                for (int i = 0; i < bits.Length; i++)
                {
                    if (bits[i] == true)
                    {
                        bits[i] = false;
                    }
                    else
                    {
                        bits[i] = true;
                        break;
                    }
                }
                return -BitArray2Int(bits);
            }
            else
            {
                return BitArray2Int(bits);
            }

        }

        // A2 Complement function from BitArray (bytes have to be already reversed)
        public static int TwosComplement2Int_fromBitArray(BitArray bits)
        {
            if (bits[bits.Length - 1] == true)
            {
                // Ones complement
                for (int i = 0; i < bits.Length; i++)
                {
                    bits[i] = !bits[i];
                }

                // Twos complement
                for (int i = 0; i < bits.Length; i++)
                {
                    if (bits[i] == true)
                    {
                        bits[i] = false;
                    }
                    else
                    {
                        bits[i] = true;
                        break;
                    }
                }
                return -BitArray2Int(bits);
            }
            else
            {
                return BitArray2Int(bits);
            }

        }

        // BitArray to a number
        // Si hay mas de 8 bits (mas de 1 byte), el array de bytes ya tien que estar Reversed() para que esta funcion funcione
        public static int BitArray2Int(BitArray bits)
        {
            int value = 0;

            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    value += Convert.ToInt32(Math.Pow(2, i));
            }

            return value;
        }







        /// TO REMOVE IN A FUTURE ???
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

    }
}
