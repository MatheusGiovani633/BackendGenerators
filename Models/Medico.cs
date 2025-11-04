
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackendGenerators.Models.Dtos;
namespace BackendGenerators.Models
{
    public class Medico 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cod_Medico { get; set; }
        
        [Required]
        public int Cod_Pessoa { get; set; }

        [ForeignKey("Cod_Pessoa")]
        public virtual Pessoa Pessoa { get; set; }

        [Required]
        public int CRM { get; set; }
        internal object Adapt<T>()
        {
            if (typeof(T) == typeof(MedicoDto))
            {
                var dto = new MedicoDto
                {
                    CRM = CRM,
                    Identificador = Pessoa.Identificador,
                    Nome = Pessoa.Nome,
                    Email = Pessoa.Email,
                    Telefone = Pessoa.Telefone,
                    Celular = Pessoa.Celular,
                    Celular2 = Pessoa.Celular2,
                    DataNascimento = Pessoa.DataNascimento,
                    Cpf = Pessoa.Cpf,
                    Sexo = Pessoa.Sexo,
                    Cep = Pessoa.Cep,
                    Logradouro = Pessoa.Logradouro,
                    Numero = Pessoa.Numero,
                    Cidade = Pessoa.Cidade,
                    Estado = Pessoa.Estado,
                    Complemento = Pessoa.Complemento,
                    Bairro = Pessoa.Bairro,
                };
                return (T)(object)dto;
            }
            throw new NotImplementedException($"Adaptation to {typeof(T).Name} is not implemented.");
        }
    }
    
}