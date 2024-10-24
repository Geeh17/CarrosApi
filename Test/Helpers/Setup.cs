using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using MinimalApi.Dominio.Interfaces;
using Test.Mocks;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace Test.Helpers
{
    public class Setup
    {
        public const string PORT = "5001";
        public WebApplicationFactory<Startup> http; 
        public HttpClient client; 

        public Setup()
        {
            http = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.UseSetting("https_port", PORT).UseEnvironment("Testing");

                    builder.ConfigureServices(services =>
                    {
                        services.AddScoped<IAdministradorServico, AdministradorServicoMock>();
                    });
                });

            client = http.CreateClient();
        }

        public void Cleanup()
        {
            client.Dispose();
            http.Dispose();
        }
    }
}
