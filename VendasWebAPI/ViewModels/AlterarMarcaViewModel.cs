using System.ComponentModel.DataAnnotations;

namespace VendasWebAPI.ViewModels
{
    public class AlterarMarcaViewModel
    {
        [RegularExpression(@"^\d*[1-9]\d*$", ErrorMessage = "O Id e obrigatorio.")]
        public int Id { get; set; }
       
        [Required(ErrorMessage = "O nome e Obrigatorio.")]
        public string Nome { get; set; }    
    }
}
