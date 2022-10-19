using System.ComponentModel.DataAnnotations;

namespace VendasWebAPI.ViewModels
{
    public class AlterarCategoriaViewModel
    {


        [RegularExpression(@"^\d*[1-9]\d*$", ErrorMessage = "A quantidadde e obrigatoria.")]

        public int Id { get; set; }


        [Required(ErrorMessage = "O nome e Obrigatorio.")]
        public string Nome { get; set; }


    }
}
