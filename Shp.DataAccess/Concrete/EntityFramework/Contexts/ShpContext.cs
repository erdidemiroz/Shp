using Microsoft.EntityFrameworkCore;
using Shp.Core.Entities.Concrete;
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
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaims> OperationClaims { get; set; }
        public DbSet<UserOperationClaims> UserOperationClaims { get; set; }
    }
}
