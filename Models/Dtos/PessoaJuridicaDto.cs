
namespace BackendGenerators.Models.Dtos
{
    public class PessoaJuridicaDto
    {
        public int Identificador { get; set; }
        public string Nome { get; set; }
        public string Razaosocial { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Celular2 { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cnpj { get; set; }
        public bool Sexo { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public int TipoCNPJ { get; set; }
    }
}