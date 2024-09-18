
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

namespace Test.Domain.Servicos;

[TestClass]
public class VeiculoServicoTest
{

    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "","..", "..", ".."));

        //Configurar o ConfigurationBuilder
        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
        

    }

    [TestMethod]
    public void TestandoSalvarVeiculo()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE veiculos");

        var veiculo = new Veiculo();
        
        veiculo.Nome = "NomeTeste2";
        veiculo.Marca = "MarcaTeste2";
        veiculo.Ano = 2024;

        var veiculoServico = new VeiculoServico(context);

        // Act
        veiculoServico.Incluir(veiculo);
        var admDoBanco = veiculoServico.BuscaPorId(veiculo.Id);
        
        

        //Assert
        Assert.AreEqual(1, veiculoServico.Todos(1).Count());
        Assert.AreEqual("NomeTeste2", veiculo.Nome);
        Assert.AreEqual("MarcaTeste2", veiculo.Marca);
        Assert.AreEqual(2024, veiculo.Ano);

    }
}