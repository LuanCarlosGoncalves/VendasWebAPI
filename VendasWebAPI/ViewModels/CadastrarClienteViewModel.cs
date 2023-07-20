using System.ComponentModel.DataAnnotations;

namespace VendasWebAPI.ViewModels
{
    public class CadastrarClienteViewModel
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }
    }
}
