using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasWebAPI.Entities
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }    

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
