using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace WebXantaquaApi.Data.Context
{
    public class WebXantaquaApiDBContext : IdentityDbContext<Client>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Budget> Budgets { get; set; }

        public WebXantaquaApiDBContext(DbContextOptions<WebXantaquaApiDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar a relação Client-Project
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Projects)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade); // Exemplo de deleção em cascata

            // Configurar a relação Project-Budget
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Budgets)
                .WithOne(b => b.Project)
                .HasForeignKey(b => b.ProjectId)
                .OnDelete(DeleteBehavior.Cascade); // Ajuste conforme a necessidade de negócio

            // Configuração de precisão para o campo decimal em Budget
            modelBuilder.Entity<Budget>()
                .Property(b => b.TotalValue)
                .HasPrecision(20, 4); // Definindo a precisão e a escala para o valor decimal
        }
    }
}