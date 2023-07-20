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



        

          

        

        



    }
}
