using Xunit;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Test.Domain.Entidades
{
    public class AdministradorTest : IDisposable 
    {
        private readonly DbContexto _context;
        private readonly AdministradorServico _administradorServico;

        public AdministradorTest()
        {
            _context = CriarContextoDeTeste();
            _administradorServico = new AdministradorServico(_context);
        }

        private DbContexto CriarContextoDeTeste()
        {
            var options = new DbContextOptionsBuilder<DbContexto>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_" + Guid.NewGuid().ToString())

            return new DbContexto(options);
        }

        [Fact]
        public void TestandoSalvarAdministrador()
        {
            var adm = new Administrador
            {
                Email = "teste@teste.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            _administradorServico.Incluir(adm);
            _context.SaveChanges();

            Assert.Equal(1, _administradorServico.Todos(1).Count());

        [Fact]
        public void TestandoBuscaPorId()
        {
            var adm = new Administrador
            {
                Email = "teste@teste.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            _administradorServico.Incluir(adm);
            _context.SaveChanges();

            var admDoBanco = _administradorServico.BuscaPorId(adm.Id);

            Assert.Equal(adm.Id, admDoBanco?.Id);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
