using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BackendGenerators.Models
{
    public class OrdemServicoCaixa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cod_OrdemServicocaixa { get; set; }
        public int Cod_Classificacao { get; set; }
        public int Cod_Pessoa { get; set; }
        public int Cod_Usuario { get; set; }
        public int Cod_Vendedor { get; set; }
        public int Cod_Receita { get; set; }
        public int Cod_Transacao { get; set; }
        public int NumeroOrdemServico { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataPrevisao { get; set; }
        public DateTime DataPrevisaoFornecedor { get; set; }
        public DateTime DataEncerramento { get; set; }
        public int Status { get; set; }
        public string Observacoes { get; set; }
        public int Cod_Laboratorio { get; set; }
        public List<int> Cod_produto { get; set; }
        public List<decimal> Quantidade { get; set; }
        public List<decimal> ValorUnitario { get; set; }
        public List<decimal> Total { get; set; }
        public List<int> Cod_Servico { get; set; }
        public List<decimal> QuantidadeServico { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorAcrescimo { get; set; }
        

    }
}