using System;
using System.Collections;
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
            byte octet1 = 4;
            cat10.MessageType(octet1);
            Console.WriteLine(cat10.data.MessageType);
            */

            /// TEST OF TWOSCOMPLEMENT() FUNCTION FROM FUNCTIONS CLASS
            //Console.WriteLine(Functions.TwosComplement2Int("1111101100110001")); //-1231
            //byte[] bytes = new byte[1] {179};
            //Console.WriteLine(Functions.TwosComplement2Int2(bytes)); //-1231

            /// TEST OF BITARRAY
            /*
            byte[] bytes = new byte[1] {8};
            Console.WriteLine(bytes[0]);
            bytes.Reverse();
            Console.WriteLine(bytes[0]);
            */
            /*
            BitArray bits = new BitArray(3);
            bits[0] = true;
            Console.WriteLine(bits.Length);
            bits.Length = bits.Length - 2;
            Console.WriteLine(bits.Length);
            Console.WriteLine(bits[bits.Length - 1]);
            Console.WriteLine(Convert.ToInt32(bits[bits.Length-1]));
            */

            /// TEST OF TargetReportDescriptor() FUNCTION DECODER FROM CAT10 CLASS
            /*
            //byte[] bytes = new byte[2] { 2, 0 };
            //Console.WriteLine((bytes[0] << 8) | bytes[1]);
            CAT10 cat10 = new CAT10();
            BitArray bits = new BitArray(bytes);
            cat10.TargetReportDescriptor(bytes);
            Console.WriteLine(cat10.data.TargetReportDescriptor_TYP);
            */

            /// TEST OF CombineBytes() FUNCTION
            /*
            byte[] bytes = new byte[4] { 1, 0, 0, 0 };
            Console.WriteLine(Functions.CombineBytes2Int(bytes)); // 16777216
            */

            time.Stop();
            Console.WriteLine(time.Elapsed);
            Console.ReadLine();
        }

        // Testing readFile function
        private static void test_readFile()
        {
            string path = @"D:\Proyectos\PGTA_UPC\Archivos AST\201002-lebl-080001_smr.ast";
            ReadFile readFile = new ReadFile(path);
        }

    }
}
