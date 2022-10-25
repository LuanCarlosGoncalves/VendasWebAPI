using System.ComponentModel.DataAnnotations;

namespace VendasWebAPI.ViewModels
{
    public class AlterarClienteViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome e Obrigatorio.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O telefone e Obrigatorio.")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O telefone e Obrigatorio.")]
        public string Endereco { get; set; }    







    }
}
