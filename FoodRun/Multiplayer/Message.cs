using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRunners
{
    class Message
    {
        public byte[] Data { get; set; }

        public Message()
        {
            Data = new byte[4096];
        }

        public void PacketWrapper(byte[] data)
        {
            byte[] packetSize = BitConverter.GetBytes(data.Length);
            Data = new byte[data.Length + packetSize.Length];
            packetSize.CopyTo(Data, 0);
            data.CopyTo(Data, packetSize.Length);

        }
    }
}
