using Microsoft.EntityFrameworkCore;

namespace VendasWebAPI.Entities
{
    public class MySQLDBContext : DbContext
    {
        public MySQLDBContext(DbContextOptions<MySQLDBContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Vendedor> Vendedor { get; set; }   

        public DbSet<Marca> Marca { get; set; }
       
        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Venda> Venda { get; set; } 

        public DbSet<ItemVenda> ItemVenda { get; set; } 

        public DbSet<ItemVenda> ItemVendas { get; set; }

    }
}
