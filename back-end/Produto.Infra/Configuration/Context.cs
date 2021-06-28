using Microsoft.EntityFrameworkCore;
using Produto.Domain.Entities;

namespace Produto.Infra.Configuration
{
    public class Context : DbContext
    {
        private readonly SQLConfiguration _sqlConfiguration;

        public Context(SQLConfiguration sqlConfiguration)
        {
            _sqlConfiguration = sqlConfiguration;
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_sqlConfiguration.ConnectionString);
        }
    }
}
