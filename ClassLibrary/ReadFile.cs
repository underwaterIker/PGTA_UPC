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
        // Two Lists containing all CAT10 & CAT21 messages
        public List<CAT10> CAT10_list = new List<CAT10>();
        public List<CAT21> CAT21_list = new List<CAT21>();

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
                    CAT10 CAT10_data = new CAT10(CAT10_message);
                    this.CAT10_list.Add(CAT10_data);
                }
                else if (cat == 21)
                {
                    byte[] CAT21_message = new byte[length - 3];
                    for (int j = 0, k = i; j < length - 3; j++, k++)
                    {
                        CAT21_message[j] = file_byte[k + 3];
                    }
                    CAT21 CAT21_data = new CAT21(CAT21_message);
                    this.CAT21_list.Add(CAT21_data);
                }
                else
                {
                    //Console.WriteLine(cat);
                    Console.WriteLine("Error");
                }
                i = i + length;
            }
        }

        // Return CAT10_list
        public List<CAT10> return_CAT10_list()
        {
            return this.CAT10_list;
        }

        // Return CAT21_list
        public List<CAT21> return_CAT21_list()
        {
            return this.CAT21_list;
        }
    }
}
