using Grpc.Core;
using GrpcServer.Protos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class CustomersService : Customer.CustomerBase
    {
        private readonly ILogger<CustomersService> _logger;
        public CustomersService(ILogger<CustomersService> logger)
        {
            _logger = logger;
        }
        public override Task<CustomerModel> GetCustormerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            CustomerModel output = new CustomerModel();
            if (request.UserId == 1)
            {
                output.FirstName = "Jamie";
                output.LastName = "Smith";
            }
            else if (request.UserId == 2)
            {
                output.FirstName = "Jane";
                output.LastName = "Doe";
            }
            else if (request.UserId == 3)
            {
                output.FirstName = "Greg";
                output.LastName = "Thomas";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Requested Customer was not found! => ID : {request.UserId}");
                Console.WriteLine();
            }
            if (output.FirstName != ""&& output.LastName != "")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Customer found! => ID : {request.UserId}");
                Console.WriteLine();
            }
            return Task.FromResult(output);
        }
    }
}
