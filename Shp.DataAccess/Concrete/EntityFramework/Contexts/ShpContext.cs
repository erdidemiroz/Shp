using Microsoft.EntityFrameworkCore;
using Shp.Entities.Concrete;

namespace Shp.DataAccess.Concrete.EntityFramework.Contexts
{
    public class ShpContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=M1-N112;Database=shp;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }
    }
}
