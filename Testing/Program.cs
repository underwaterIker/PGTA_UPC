using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            /// Here goes the function to be tested

            /// TEST OF READFILE() FUNCTION FROM FUNCTIONS CLASS
            //test_readFile();

            /// TEST OF MESSAGETYPE() FUNCTION DECODER FROM CAT10 CLASS
            /*
            CAT10 cat10 = new CAT10();
            cat10.MessageType("00000100");
            Console.WriteLine(cat10.data.MessageType);
            */

            /// TEST OF TWOSCOMPLEMENT() FUNCTION FROM FUNCTIONS CLASS
            //Console.WriteLine(Functions.TwosComplement2Int("1111101100110001")); //-1231

            time.Stop();
            Console.WriteLine(time.Elapsed);
            Console.ReadLine();
        }

        private static void test_readFile()
        {
            // Testing readFile function
            string path = @"D:\Proyectos\PGTA_UPC\Archivos AST\201002-lebl-080001_smr.ast";
            string[] file = Functions.readFile(path);

            Console.WriteLine(file[0]);
            Console.WriteLine(file[1]);
            Console.WriteLine(file[2]);

            /// ALTERNATIVE METHODS (BYTE[] TO STRING[])
            /*
            string[] str = new string[file.Length];
            for (int i = 0; i < file.Length; i++)
            {
                str[i] = Convert.ToString(file[i], 2).PadLeft(8, '0');
                
            }
            */

            //char[] file_string = BitConverter.ToString(file_byte).ToCharArray();

            //string[] str = file.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray();
        }
    }
}
