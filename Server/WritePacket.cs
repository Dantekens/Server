using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class WritePacket
    {
        public string Login { get; set; }
        public string Text { get; set; }
        public DateTime DateSend { get; set; }
    }
}
