using Microsoft.EntityFrameworkCore;

namespace Krpc.Data.Context
{
    public class WebKrpcApiDBContext : DbContext
    {
        public DbSet<Client> Clientes { get; set; }
        public DbSet<Project> Projetos { get; set; }
        public DbSet<Budget> Orcamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=WebKrpcApi;Trusted_Connection=True;");
        }

    }
}