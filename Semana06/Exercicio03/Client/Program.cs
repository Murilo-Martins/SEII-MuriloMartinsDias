
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

class Program
{
    static byte[] Buffer {get; set;}
    static Socket sck;
    static void Main(string[] args)
    {
        sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),1234);
        try
        {
            sck.Connect(localEndPoint);

        }
        catch (System.Exception)
        {
            
            Console.Write("Unable to connect to remote end point \r\n");
            Main(args);
        }
        Console.Write("Enter text: ");
        string text = Console.ReadLine();
        byte[] data = Encoding.ASCII.GetBytes(text);

        sck.Send(data);
        Console.Write("Data Send \r\n");
        Console.Write("Press any key");
        Console.Read();
        sck.Close();
    
    }
}