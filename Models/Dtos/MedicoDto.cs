
namespace BackendGenerators.Models.Dtos
{
    public class MedicoDto : PessoaDto
    {
        public int CRM { get; set; }
        public new int Identificador { get; set; }
        public new string Nome { get; set; }
        public new string Email { get; set; }
        public new string Telefone { get; set; }
        public new string Celular { get; set; }
        public new string Celular2 { get; set; }
        public new DateTime DataNascimento { get; set; }
        public new string Cpf { get; set; }
        public new bool Sexo { get; set; }
        public new string Cep { get; set; }
        public new string Logradouro { get; set; }
        public new string Numero { get; set; }
        public new string Cidade { get; set; }
        public new string Estado { get; set; }
        public new string Complemento { get; set; }
        public new string Bairro { get; set; }
    }
}