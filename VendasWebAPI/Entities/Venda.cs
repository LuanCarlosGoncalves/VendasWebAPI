using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasWebAPI.Entities
{
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public DateTime Data { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<ItemVenda> ItemVendas { get; set; }
    }
}
