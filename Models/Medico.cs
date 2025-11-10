
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    }
    
}