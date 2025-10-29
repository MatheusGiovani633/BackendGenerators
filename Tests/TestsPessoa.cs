
namespace Tests.TestsPessoa
{
    using BackendGenerators.Helpers;
    using Xunit;
    public class GerarPessoa
    {
        [Fact]
        public void CriarPessoaFisica()
        {
            var pessoaFisica = Helpers.CriarFisica();
            Assert.NotNull(pessoaFisica);
            Assert.False(string.IsNullOrWhiteSpace(pessoaFisica.Nome), "Nome não deve estar vazio");
            Assert.False(string.IsNullOrWhiteSpace(pessoaFisica.Cpf), "CPF não deve estar vazio");
            Assert.True(pessoaFisica.Identificador > 0, "Identificador deve ser maior que zero");
        }

        [Fact]
        public void CriarPessoaJuridica()
        {
            var pessoaJuridica = Helpers.CriarJuridica();
            Assert.NotNull(pessoaJuridica);
            Assert.False(string.IsNullOrWhiteSpace(pessoaJuridica.Nome), "Nome não deve estar vazio");
            Assert.False(string.IsNullOrWhiteSpace(pessoaJuridica.Cnpj), "CNPJ não deve estar vazio");
            Assert.True(pessoaJuridica.Identificador > 0, "Identificador deve ser maior que zero");
        }
        

    }
}