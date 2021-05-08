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
        // GET: Producto
        public ActionResult Index()
        {
            LogicaProductos logicaProductos = new LogicaProductos();
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

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
