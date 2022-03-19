using DemoMinimalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMinimalAPI.Data
{
    public class MinimalContextDb : DbContext
    {
        public MinimalContextDb(DbContextOptions<MinimalContextDb> options) : base(options) { }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Fornecedor>()
                .HasKey(f => f.Id);

            builder.Entity<Fornecedor>()
                .Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Entity<Fornecedor>()
                .Property(f => f.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Entity<Fornecedor>()
                .ToTable("Fornecedores");

            base.OnModelCreating(builder);
        }
    }
}
