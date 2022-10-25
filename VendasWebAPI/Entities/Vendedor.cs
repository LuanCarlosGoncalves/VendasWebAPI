using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasWebAPI.Entities
{
    public class Vendedor
    {
        [Key]//chave primaria
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]// sempre quando for Id (auto incremento para gerar o Id automaticamente)      
        public int Id { get; set; } 
       
        public string Nome { get; set; }
    
        public string Telefone { get; set; }
       
        public DateTime? DataNascimento { get; set; }

        public string CPF { get; internal set; }

        public virtual ICollection<Venda> Vendas { get; set; }

    }
}
