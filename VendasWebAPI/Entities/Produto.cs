using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasWebAPI.Entities
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cor { get; set; }

        [Precision(10, 2)]
        public decimal Valor { get; set; }

        public int Quantidade { get; set; }

        public int CategoriaId { get; set; }

        public int MarcaId { get; set; }
    }
}
