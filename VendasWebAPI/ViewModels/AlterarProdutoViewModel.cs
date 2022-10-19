using System.ComponentModel.DataAnnotations;

namespace VendasWebAPI.ViewModels
{
    public class AlterarProdutoViewModel
    {
        [RegularExpression(@"^\d*[1-9]\d*$", ErrorMessage = "O Id e obrigatorio.")]
        
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome e Obrigatorio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Cor e Obrigatorio.")]
        public string Cor { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = " O valor deve estar entre 1 e 2147483647.")]
        public decimal Valor { get; set; }

        [RegularExpression(@"^\d*[1-9]\d*$", ErrorMessage = "A quantidadde e obrigatoria.")]
        public int Quantidade { get; set; }

    }
}
