using System.ComponentModel.DataAnnotations;

namespace VendasWebAPI.ViewModels
{
    public class CadastrarCategoriaViewModel
    {

        [Required(ErrorMessage = "O nome e Obrigatorio.")]
        public string Nome { get; set; }

    }
}
