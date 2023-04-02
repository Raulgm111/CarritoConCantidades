using CarritoConCantidades.Models;
using Microsoft.EntityFrameworkCore;

namespace CarritoConCantidades.Data
{
    public class ProductosContext : DbContext
    {
        public ProductosContext(DbContextOptions<ProductosContext> options)
            : base(options) { }

        public DbSet<Producto> Productos { get; set; }
    }
}
