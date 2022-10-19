using System.ComponentModel.DataAnnotations;

namespace VendasWebAPI.ViewModels
{
    public class CadastrarVendedorViewModel
    {

        [Required(ErrorMessage = "O nome e Obrigatorio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone e Obrigatorio.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O cpf e Obrigatorio.")]
        public string CPF { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
