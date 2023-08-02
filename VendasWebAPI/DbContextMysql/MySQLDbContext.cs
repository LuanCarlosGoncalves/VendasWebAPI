using Microsoft.EntityFrameworkCore;
using VendasWebAPI.Entidades;

namespace VendasWebAPI.DbContextMysql
{
    public class MySQLDbContext : DbContext
    {
        public MySQLDbContext(DbContextOptions<MySQLDbContext> options)
            : base(options) { }


        
            public virtual DbSet<Cliente> Cliente { get; set; }

            public virtual DbSet<Funcionario> Funcionario { get; set; }

            public virtual DbSet<Marca> Marca { get; set; }

            public virtual DbSet<Categoria> Categoria { get; set; }

            public virtual DbSet<Modelo> Modelo { get; set; }

            public virtual DbSet<Vendedor> Vendedor { get; set; }



        

          

        

        



    }
}
