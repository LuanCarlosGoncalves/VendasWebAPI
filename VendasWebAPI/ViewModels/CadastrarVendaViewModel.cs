namespace VendasWebAPI.ViewModels
{
    public class CadastrarVendaViewModel
    {
       public int VendedorId  { get; set; }

       public int ClienteId  { get; set; }
    
       public List<ItemVendaViewModel> ItemVendas { get; set; }

    }
}
