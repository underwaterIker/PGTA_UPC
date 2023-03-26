using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CAT10
    {
        // Content of the CAT10 message
        string[] message; // Maybe its useless
        
        Data data = new Data();

        // Dictionary
        private IDictionary<int, string> MessageType_dict = new Dictionary<int, string>() { { 1, "Target Report" }, { 2, "Start of Update Cycle" }, { 3, "Periodic Status Message" }, { 4, "Event-triggered Status Message" } };

        public CAT10(string[] message)
        {
            this.message = message; // Maybe its useless



            // Aqui dentro vamos a ir decodificando el mensaje usando las funciones que vamos
            // a crear en esta misma clase. De esta manera, cuando llamemos a esta funcion ya
            // va a quedar todo decodificado
        }

        // Data Item I010/000, Message Type
        private void MessageType(string octet1)
        {
            data.MessageType = MessageType_dict[Convert.ToInt16(octet1, 2)];
        }

        // Data Item I010/041, Position in WGS-84 Co-ordinates
        private void PositionWGS84Coordinates(string[] octets)
        {
            double LSB = 180 / Math.Pow(2, 31);
            //double latitude = Functions.TwosComplement(octets[0] + octets[1] + octets[2] + octets[3]);
        }
    }
}
