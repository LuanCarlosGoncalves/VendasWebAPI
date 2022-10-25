using System.ComponentModel.DataAnnotations;

namespace VendasWebAPI.ViewModels
{
    public class CadastrarClienteViewModel
    {
        [Required(ErrorMessage = "O nome e Obrigatorio.")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O telefone e Obrigatorio.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O endereco e Obrigatorio.")]
        public string Endereco { get; set; }
        public int Id { get; internal set; }
    }
}
