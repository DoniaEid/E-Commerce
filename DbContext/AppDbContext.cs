
using E_Commerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DbContext
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductVariant> ProductVariant { get; set; }
        public DbSet<Color> Color{ get; set; }
        public DbSet<Size> Size{ get; set; }
        public DbSet<Category> Category { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
