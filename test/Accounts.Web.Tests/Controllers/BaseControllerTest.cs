using Microsoft.AspNet.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Accounts.Web.Tests.Controllers
{
    public class BaseControllerTest
    {
        internal readonly TestServer _server;
        internal readonly HttpClient _client;
        internal IServiceProvider _serviceProvider;

        public BaseControllerTest()
        {

            _server = new TestServer(TestServer.CreateBuilder()
                .UseStartup<Startup>());
            _server.BaseAddress = new Uri("http://localhost:5000");
            _client = _server.CreateClient();

            _serviceProvider = new ServiceCollection().BuildServiceProvider();
        }
    }
}
