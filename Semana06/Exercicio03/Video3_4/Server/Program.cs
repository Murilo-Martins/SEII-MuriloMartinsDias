
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

class Program
{
    static Socket sck;
    static void Main(string[] args)
    {
        sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        sck.Bind(new IPEndPoint(0,1994));
        sck.Listen(0);
        
        Socket acc = sck.Accept();
        
        byte[] buffer = Encoding.Default.GetBytes("Olá meu mundo");
        acc.Send(buffer,0,buffer.Length,0);
        buffer = new byte[255];
        int rec = acc.Receive(buffer,0,buffer.Length,0);
        Array.Resize(ref buffer, rec);
        Console.WriteLine("Received: {0}",Encoding.Default.GetString(buffer));

        
        Console.Read();
        sck.Close();
        acc.Close();

    
    }
}