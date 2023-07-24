using Meu_Projeto.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Meu_Projeto.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Products>().Property(p => p.Description).HasMaxLength(255);
            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired();
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {
            configuration.Properties<string>().HaveMaxLength(100);

        }

    }
}
