
using minimal_api.Dominio.Entidades;
namespace Test.Domain.Entidades;

[TestClass]
public class VeiculosTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        // Arrange
        var veiculo = new Veiculo();

        // Act
        veiculo.Id = 1;
        veiculo.Nome = "NomeTeste";
        veiculo.Marca = "MarcaTeste";
        veiculo.Ano = 2024;

        //Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("NomeTeste", veiculo.Nome);
        Assert.AreEqual("MarcaTeste", veiculo.Marca);
        Assert.AreEqual(2024, veiculo.Ano);

    }
}