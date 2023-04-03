using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CAT21
    {
        // Content of the CAT21 message
        byte[] message { get; set; } // Maybe its useless

        // Bytes of the FSPEC
        public byte[] FSPEC { get; set; }

        // Where the decodificated data will be stored
        public CAT21_Data data = new CAT21_Data();


        // CONSTRUCTOR
        public CAT21(byte[] message)
        {
            this.message = message;
        }
    }
}
