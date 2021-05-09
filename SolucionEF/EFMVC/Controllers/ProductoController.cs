using EFCapaLogica;
using EFEntities;
using EFMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EFMVC.Controllers
{
    public class ProductoController : Controller
    {
        LogicaProductos logicaProductos = new LogicaProductos();

        // GET: Producto
        public ActionResult Index()
        {
            List<Products> listaProductos = logicaProductos.ObtenerTodos();
            List<ProductoView> listaVistaProducto = listaProductos.Select(p => new ProductoView
            {
                Id = p.ProductID,
                Nombre = p.ProductName,
                CantidadPorUnidad = p.QuantityPerUnit,
                PrecioUnitario = (decimal)p.UnitPrice
            }).ToList();
            return View(listaVistaProducto);
        }

        // GET: Producto/Ver/5
        public ActionResult Ver(int id)
        {
            Products producto = logicaProductos.BuscarProductoPorId(id);
            ProductoView productView = new ProductoView 
            {
                Id = producto.ProductID,
                Nombre = producto.ProductName,
                CantidadPorUnidad = producto.QuantityPerUnit,
                PrecioUnitario = (decimal)producto.UnitPrice
            };
            
            return View(productView);
        }

        // GET: Producto/AltaProducto
        public ActionResult AltaProducto()
        {

            return View();
        }


        // POST: Producto/AltaProducto
        [HttpPost]
        public ActionResult AltaProducto(ProductoView producto)
        {
            try
            {
                Products p = new Products
                {
                    ProductID = producto.Id,
                    ProductName = producto.Nombre,
                    QuantityPerUnit = producto.CantidadPorUnidad,
                    UnitPrice = producto.PrecioUnitario
                };

                logicaProductos.Agregar(p);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Producto/Editar/5
        public ActionResult Editar(int id)
        {

            Products producto = logicaProductos.BuscarProductoPorId(id);
            ProductoView productoView = new ProductoView
            {
                Id = producto.ProductID,
                Nombre = producto.ProductName,
                CantidadPorUnidad = producto.QuantityPerUnit,
                PrecioUnitario = (decimal)producto.UnitPrice,
            };
            return View(productoView);
        }

        // POST: Producto/Editar/5
        [HttpPost]
        public ActionResult Editar(int id, ProductoView producto)
        {
            try
            {
                Products p = new Products();
                p.ProductID = id;
                p.ProductName = producto.Nombre;
                p.UnitPrice = producto.PrecioUnitario;
                p.QuantityPerUnit = producto.CantidadPorUnidad;

                logicaProductos.Actualizar(p);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Borrar(int id)
        {
            logicaProductos.Borrar(id);
            return RedirectToAction("Index");
        }
    }
}
