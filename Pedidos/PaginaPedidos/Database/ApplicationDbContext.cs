using Microsoft.EntityFrameworkCore;
using PaginaPedidos.Models;

namespace PaginaPedidos.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Categoria> Categorias { get; set; } 
        public DbSet<Product> Products { get; set; }
    }
}
