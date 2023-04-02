using CarritoConCantidades.Data;
using CarritoConCantidades.Models;

namespace CarritoConCantidades.Repositories
{
    public class RepositoryProductos
    {
        private ProductosContext context;

        public RepositoryProductos(ProductosContext context)
        {
            this.context = context;
        }

        public List<Producto> GetTodosProductos()
        {
            var consulta = from datos in context.Productos
                           select datos;
            return consulta.ToList();
        }

        public List<Producto> BuscarProductoCarrito(List<int>? idproductoCarrito)
        {
            var consulta = from datos in this.context.Productos
                           where idproductoCarrito.Contains(datos.IdBebida)
                           select datos;
            return consulta.ToList();
        }
    }
}
