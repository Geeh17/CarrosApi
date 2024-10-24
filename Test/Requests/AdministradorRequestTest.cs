using System.Net.Http;
using System.Threading.Tasks;
using Test.Helpers; // Importar o namespace que contém a classe Setup
using Xunit;

namespace Test.Requests
{
    public class AdministradorRequestTest
    {
        private readonly Setup _setup;

        public AdministradorRequestTest()
        {
            _setup = new Setup(); // Inicializa o ambiente de teste
        }

        [Fact]
        public async Task TestandoRequisicaoAdministrador()
        {
            var response = await _setup.client.GetAsync("/api/administradores");
            response.EnsureSuccessStatusCode();

            // Validações adicionais podem ser adicionadas aqui
        }

        [Fact]
        public async Task TestandoRequisicaoAdministradorPorId()
        {
            var idExistente = 1; // Supondo que esse ID exista
            var response = await _setup.client.GetAsync($"/api/administradores/{idExistente}");
            response.EnsureSuccessStatusCode();
        }
    }
}
