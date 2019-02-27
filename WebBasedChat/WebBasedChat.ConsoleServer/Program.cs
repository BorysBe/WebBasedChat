using System;
using WebBasedChat.Server;

namespace WebBasedChat.ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Server is starting ...");
            var server = new Server.Server(new MemoryRepository());
            Console.WriteLine($"Server started on {server.Address}");
            Console.ReadLine();
        }
    }
}
