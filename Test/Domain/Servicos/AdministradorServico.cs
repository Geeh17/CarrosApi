using Xunit;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Test.Domain.Entidades
{
    public class AdministradorServicoTest
    {
        private DbContexto CriarContextoDeTeste()
        {
            var options = new DbContextOptionsBuilder<DbContexto>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            return new DbContexto(options);
        }

        [Fact]
        public void TestandoSalvarAdministrador()
        {
            var context = CriarContextoDeTeste();
            var administradorServico = new AdministradorServico(context);

            var adm = new Administrador
            {
                Email = "teste@teste.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            administradorServico.Incluir(adm);
            context.SaveChanges();

            Assert.Equal(1, administradorServico.Todos(1).Count()); 
        }

        [Fact]
        public void TestandoBuscaPorId()
        {
            var context = CriarContextoDeTeste();
            var administradorServico = new AdministradorServico(context);

            var adm = new Administrador
            {
                Email = "teste@teste.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            administradorServico.Incluir(adm);
            context.SaveChanges();

            var admDoBanco = administradorServico.BuscaPorId(adm.Id);

            Assert.Equal(adm.Id, admDoBanco?.Id);
        }
    }
}
