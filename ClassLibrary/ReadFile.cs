using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ClassLibrary
{
    public class ReadFile
    {
        // List containing all CAT10 & CAT21 messages in order
        public List<Data> data_list = new List<Data>();

        // CONSTRUCTOR: reads the file and fills the lists with the messages
        public ReadFile(string path)
        {
            byte[] file_byte = File.ReadAllBytes(path);

            for (int i = 0; i < file_byte.Length;)
            {
                // CAT
                int cat = file_byte[i];

                // LENGTH
                byte[] length_bytes = new byte[2] { file_byte[i + 2], file_byte[i + 1] }; // Reversed
                int length = Functions.CombineBytes2Int(length_bytes);

                // Save message in corresponding list
                if (cat == 10)
                {
                    byte[] CAT10_message = new byte[length - 3];
                    for (int j = 0, k = i; j < length - 3; j++, k++)
                    {
                        CAT10_message[j] = file_byte[k + 3];
                    }
                    CAT10 cat10 = new CAT10(CAT10_message);
                    this.data_list.Add(cat10.data);
                }
                else if (cat == 21)
                {
                    byte[] CAT21_message = new byte[length - 3];
                    for (int j = 0, k = i; j < length - 3; j++, k++)
                    {
                        CAT21_message[j] = file_byte[k + 3];
                    }
                    CAT21 cat21 = new CAT21(CAT21_message);
                    this.data_list.Add(cat21.data);
                }
                else
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("ERROR. Not expected category. --> CAT {0}", cat);
                    Console.WriteLine("--------------------------------------------");
                }
                i = i + length;
                //i = file_byte.Length;
            }
        }

    }
}
