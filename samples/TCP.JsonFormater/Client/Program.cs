﻿using System;
using System.Net;
using BeetleX;
using BeetleX.Buffers;
using BeetleX.Clients;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = SocketFactory.CreateClient<TcpClient, Messages.JsonClientPacket>("127.0.0.1", 9090);
            client.LocalEndPoint = new System.Net.IPEndPoint(IPAddress.Parse("127.0.0.1"), 9022);
            while (true)
            {
                Messages.Register register = new Messages.Register();
                Console.Write("Enter Name:");
                register.Name = Console.ReadLine();
                Console.Write("Enter Email:");
                register.EMail = Console.ReadLine();
                Console.Write("Enter City:");
                register.City = Console.ReadLine();
                Console.Write("Enter Password:");
                register.City = Console.ReadLine();
                client.SendMessage(register);
                var result = client.ReceiveMessage<Messages.Register>();
                Console.WriteLine($"{result.Name} {result.EMail} {result.City} {result.DateTime}");
            }
        }
    }


}
