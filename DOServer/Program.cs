using System;
using Darkorbit.Network;

namespace Darkorbit
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new GameServer(8080, 10);
            var chatServer = new ChatServer(9338, 10);
            var policyServer = new PolicyServer(843,10);
            server.StartAsync();
            chatServer.StartAsync();
            policyServer.StartAsync();
            //chatServer.StartAsync();
            Console.ReadKey();
        }
    }
}
