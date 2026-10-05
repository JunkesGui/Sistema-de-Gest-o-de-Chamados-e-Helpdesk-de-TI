using HelpDesk.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Chamado> Chamados {get; set;}
        public DbSet<Categoria> Categorias {get; set;}
    }
}
