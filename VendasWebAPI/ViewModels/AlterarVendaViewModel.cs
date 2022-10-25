namespace VendasWebAPI.ViewModels
{
    public class AlterarVendaViewModel
    {
        public int Id { get; set; }

        public int VendedorId { get; set; }

        public int ClienteId { get; set; }

        public List<ItemVendaViewModel> ItemVendas { get; set; }
    }
}
