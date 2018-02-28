using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketSrv
{
    class HelloServer
    {
        public void Start()
        {
	        List<Fleck.IWebSocketConnection> sockets = new List<Fleck.IWebSocketConnection>();
	        var server = new Fleck.WebSocketServer("ws://127.0.0.1:8181");
	
	        server.Start(socket => 
	        {
		        socket.OnOpen = () => 
		        {
			        Console.WriteLine("Connection open.");
			        sockets.Add(socket);
		        };
		        socket.OnClose = () =>
		        {
			        Console.WriteLine("Connection closed.");
			        sockets.Remove(socket);
		        };
		        socket.OnMessage = message => 
		        {
			        Console.WriteLine("Client Says: " + message);
			        sockets.ToList().ForEach(s => s.Send(" client says: " + message));
		        };
	        });
	
	        string input = Console.ReadLine();
	        while(input != "exit")
	        {
		        sockets.ToList().ForEach(s => s.Send(input));
		        input = Console.ReadLine();
	        }
        }
    }
}
