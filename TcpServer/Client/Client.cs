﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
// i dont remember exactly how this code works because it was some time ago i did it. so i cant do documentation
namespace TcpClient
{
    class Client
    {
        private static readonly Socket ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int Port = 100;

        static void Main()
        {
            Console.Title = "Client";
            ConnectToServer();
            RequestLoop();

            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
        }

        private static void ConnectToServer()
        {
            int attempts = 0;

            while (!ClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    Console.WriteLine("Connection attempt " + attempts);
                    ClientSocket.Connect(IPAddress.Loopback, Port);
                }
                catch (SocketException)
                {
                    Console.Clear();
                }
            }
            Console.Clear();
            Console.WriteLine("Connected");
        }

        private static void RequestLoop()
        {
            Console.WriteLine(@"<Type ""exit"" to properly disconnect client>");
            string requestSent = string.Empty;

            try
            {
                while (requestSent.ToLower() != "exit")
                {
                    Console.Write("Send a request: ");
                    requestSent = Console.ReadLine();
                    ClientSocket.Send(Encoding.UTF8.GetBytes(requestSent), SocketFlags.None);
                    ReceiveResponse();
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Error! - Lost server.");
                Console.ReadLine();
            }

        }

        private static void ReceiveResponse()
        {
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0)
                return;
            Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, received));
        }
    }
}
