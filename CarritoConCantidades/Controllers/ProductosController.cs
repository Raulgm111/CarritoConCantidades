using CarritoConCantidades.Extensions;
using CarritoConCantidades.Models;
using CarritoConCantidades.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarritoConCantidades.Controllers
{
    public class ProductosController : Controller
    {
        private RepositoryProductos repo;

        public ProductosController(RepositoryProductos repo)
        {
            this.repo = repo;
        }
        public IActionResult Index(int? idproductoCarrito)
        {
            if (idproductoCarrito != null)
            {
                List<int> carrito;
                if (HttpContext.Session.GetObject<List<int>>("CARRITO") == null)
                {
                    carrito = new List<int>();
                }
                else
                {
                    carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
                }
                if (carrito.Contains(idproductoCarrito.Value) == false)
                {
                    carrito.Add(idproductoCarrito.Value);
                    HttpContext.Session.SetObject("CARRITO", carrito);
                }
            }
            List<Producto> productos = this.repo.GetTodosProductos();
            return View(productos);
        }
        [HttpPost]
        public IActionResult Index(int idproducto, int cantidad)
        {
            List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
            if (carrito == null)
            {
                carrito = new List<int>();
            }

            for (int i = 0; i < cantidad; i++)
            {
                carrito.Add(idproducto);
            }

            HttpContext.Session.SetObject("CARRITO", carrito);
            return RedirectToAction("Index");
        }





        public IActionResult Carrito(int? idproductoCarrito)
        {
            List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
            if (carrito == null)
            {
                return View();
            }
            else
            {
                if (idproductoCarrito != null)
                {
                    carrito.RemoveAll(p => p == idproductoCarrito.Value);
                    HttpContext.Session.SetObject("CARRITO", carrito);
                }

                List<Producto> productos = this.repo.BuscarProductoCarrito(carrito);
                return View(productos);
            }
        }

    }
}
