using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Multi_Con_S;
class Program
{
    static Listener listener;
    static List<Socket> sockets;
    
    static void Main(string[] args)
    {
        listener = new Listener(8);
        listener.SocketAccepted += new Listener.SocketAcceptedHandler(l_SocketAccepted);
        listener.Start();
        Console.Read();
    }

    static void l_SocketAccepted(System.Net.Sockets.Socket e)
    {
        Console.WriteLine("New Connection: {0} \n{1} \n========", e.RemoteEndPoint, DateTime.Now);
        sockets.Add(e);
    }
}