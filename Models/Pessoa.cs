using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackendGenerators.Models.Dtos;
using Microsoft.Identity.Client;
namespace BackendGenerators.Models
{
    public class Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cod_Pessoa { get; set; }
        public virtual Medico Medico { get; set; }
        public int Identificador { get; set; }
        public string Nome { get; set; }
        public string Razaosocial { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Celular2 { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
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

        public static PessoaDto ToPessoaDto(Pessoa pessoa)
        {
            return new PessoaDto
            {
                Cod_pessoa = pessoa.Cod_Pessoa,
                Identificador = pessoa.Identificador,
                Nome = pessoa.Nome,
                Razaosocial = pessoa.Razaosocial,
                Email = pessoa.Email,
                Telefone = pessoa.Telefone,
                Celular = pessoa.Celular,
                Celular2 = pessoa.Celular2,
                DataNascimento = pessoa.DataNascimento,
                Cpf = pessoa.Cpf,
                Cnpj = pessoa.Cnpj,
                Sexo = pessoa.Sexo,
                Cep = pessoa.Cep,
                Logradouro = pessoa.Logradouro,
                Numero = pessoa.Numero,
                Cidade = pessoa.Cidade,
                Estado = pessoa.Estado,
                Complemento = pessoa.Complemento,
                Bairro = pessoa.Bairro,
                InscricaoEstadual = pessoa.InscricaoEstadual,
                InscricaoMunicipal = pessoa.InscricaoMunicipal,
                TipoCNPJ = pessoa.TipoCNPJ
            };
        }
        public static MedicoDto ToMedicoDto(Pessoa pessoa)
        {
            return new MedicoDto
            {
                CRM = pessoa.Medico.CRM,
                Identificador = pessoa.Identificador,
                Nome = pessoa.Nome,
                Email = pessoa.Email,
                Telefone = pessoa.Telefone,
                Celular = pessoa.Celular,
                Celular2 = pessoa.Celular2,
                DataNascimento = pessoa.DataNascimento,
                Cpf = pessoa.Cpf,
                Sexo = pessoa.Sexo,
                Cep = pessoa.Cep,
                Logradouro = pessoa.Logradouro,
                Numero = pessoa.Numero,
                Cidade = pessoa.Cidade,
                Estado = pessoa.Estado,
                Complemento = pessoa.Complemento,
                Bairro = pessoa.Bairro
            };
        }
        public static PessoaFisicaDto ToPessoaFisicaDto(Pessoa pessoa)
        {
            return new PessoaFisicaDto
            {
                Identificador = pessoa.Identificador,
                Nome = pessoa.Nome,
                Email = pessoa.Email,
                Telefone = pessoa.Telefone,
                Celular = pessoa.Celular,
                Celular2 = pessoa.Celular2,
                DataNascimento = pessoa.DataNascimento,
                Cpf = pessoa.Cpf,
                Sexo = pessoa.Sexo,
                Cep = pessoa.Cep,
                Logradouro = pessoa.Logradouro,
                Numero = pessoa.Numero,
                Cidade = pessoa.Cidade,
                Estado = pessoa.Estado,
                Complemento = pessoa.Complemento,
                Bairro = pessoa.Bairro,
            };
        }
        public static PessoaJuridicaDto ToPessoaJuridicaDto(Pessoa pessoa)
        {
            return new PessoaJuridicaDto
            {
                Identificador = pessoa.Identificador,
                Nome = pessoa.Nome,
                Razaosocial = pessoa.Razaosocial,
                Email = pessoa.Email,
                Telefone = pessoa.Telefone,
                Celular = pessoa.Celular,
                Celular2 = pessoa.Celular2,
                DataNascimento = pessoa.DataNascimento,
                Cnpj = pessoa.Cnpj,
                Sexo = pessoa.Sexo,
                Cep = pessoa.Cep,
                Logradouro = pessoa.Logradouro,
                Numero = pessoa.Numero,
                Cidade = pessoa.Cidade,
                Estado = pessoa.Estado,
                Complemento = pessoa.Complemento,
                Bairro = pessoa.Bairro,
                InscricaoEstadual = pessoa.InscricaoEstadual,
                InscricaoMunicipal = pessoa.InscricaoMunicipal,
                TipoCNPJ = pessoa.TipoCNPJ
            };
        }
    }

}