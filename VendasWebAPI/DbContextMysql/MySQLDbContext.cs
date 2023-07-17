using Microsoft.EntityFrameworkCore;
using VendasWebAPI.Entities;

namespace VendasWebAPI.DbContextMysql
{
    public class MySQLDbContext : DbContext
    {
        public MySQLDbContext(DbContextOptions<MySQLDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }

    }
}
