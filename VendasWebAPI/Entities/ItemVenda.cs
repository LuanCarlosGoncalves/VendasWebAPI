using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasWebAPI.Entities
{
    public class ItemVenda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Quantidade { get; set; } 

        public int VendaId { get; set; } 

        public int ProdutoId { get; set; } 

        public virtual Venda Venda { get; set; }

        public virtual Produto Produto { get; set; }

    }
}
