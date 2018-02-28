using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketSrv
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloServer server = new HelloServer();
            server.Start();
        }

    }
}
