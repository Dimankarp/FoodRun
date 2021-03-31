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
    }
}
