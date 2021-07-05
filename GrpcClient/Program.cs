using Grpc.Net.Client;
using GrpcServer;
using GrpcServer.Protos;
using System;
using System.Dynamic;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        private static string GrpcChannelAddress = "https://localhost:5001";
        static async Task Main(string[] args)
        {
            #region Greeting
            //var input = new HelloRequest { Name = "Melih" };
            //var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //var client = new Greeter.GreeterClient(channel);
            //var reply = await client.SayHelloAsync(input);
            //Console.WriteLine(reply.Message);

            #endregion
            #region Customer
            //var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //var client = new Customer.CustomerClient(channel);
            //var input = new CustomerLookupModel { UserId = 1 };

            //var reply =await client.GetCustormerInfoAsync(input);
            //Console.WriteLine(reply.FirstName+ " " + reply.LastName);
            #endregion
            var consoleInput = "";

            while (true)
            {
                Console.WriteLine("Give Me Customer Id => {1,2,3}");
                consoleInput = Console.ReadLine();
                int possibleId = -1;
                var isInt = int.TryParse(consoleInput, out possibleId);
                if (isInt == false) Environment.Exit(0);

                var channel = GrpcChannel.ForAddress(GrpcChannelAddress);
                var client = new Customer.CustomerClient(channel);
                var input = new CustomerLookupModel { UserId = possibleId };

                var reply = await client.GetCustormerInfoAsync(input);
                Console.WriteLine(reply.FirstName + " " + reply.LastName);
            }


            Console.ReadLine();
        }
    }
}
