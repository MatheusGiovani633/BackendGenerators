using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackendGenerators.Models.Dtos;
namespace BackendGenerators.Models
{

    public class Receita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cod_Receita { get; set; }

        [Required]
        public int Cod_Pessoa { get; set; }

        [ForeignKey("Cod_Pessoa")]
        public virtual Pessoa Pessoa { get; set; }

        public int Cod_OrdemServicocaixa { get; set; }
        public int Cod_Vendedor { get; set; }
        public int Cod_Medico { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataPrescricao { get; set; }
        public DateTime DataAviamento { get; set; }
        public decimal LenteOD { get; set; }
        public decimal LenteOE { get; set; }
        public decimal Altura { get; set; }
        public decimal esfericoOD { get; set; }
        public decimal esfericoOE { get; set; }
        public decimal cilindricoOD { get; set; }
        public decimal cilindricoOE { get; set; }
        public decimal eixoOD { get; set; }
        public decimal eixoOE { get; set; }
        public decimal AdicaoOD { get; set; }
        public decimal AdicaoOE { get; set; }
        public decimal DNPOD { get; set; }
        public decimal DNPOE { get; set; }
        public decimal COOD { get; set; }
        public decimal COOE { get; set; }
        public string Observacoes { get; set; }
        public static ReceitaDto ToReceitaDto(Receita receita)
        {
            return new ReceitaDto
            {
                Cod_Pessoa = receita.Cod_Pessoa,
                Cod_OrdemServicocaixa = receita.Cod_OrdemServicocaixa,
                Cod_Vendedor = receita.Cod_Vendedor,
                Cod_Medico = receita.Cod_Medico,
                DataEmissao = receita.DataEmissao,
                DataPrescricao = receita.DataPrescricao,
                DataAviamento = receita.DataAviamento,
                LenteOD = receita.LenteOD,
                LenteOE = receita.LenteOE,
                Altura = receita.Altura,
                esfericoOD = receita.esfericoOD,
                esfericoOE = receita.esfericoOE,
                cilindricoOD = receita.cilindricoOD,
                cilindricoOE = receita.cilindricoOE,
                eixoOD = receita.eixoOD,
                eixoOE = receita.eixoOE,
                AdicaoOD = receita.AdicaoOD,
                AdicaoOE = receita.AdicaoOE,
                DNPOD = receita.DNPOD,
                DNPOE = receita.DNPOE,
                COOD = receita.COOD,
                COOE = receita.COOE,
                Observacoes = receita.Observacoes
            };
        }
    }

}

