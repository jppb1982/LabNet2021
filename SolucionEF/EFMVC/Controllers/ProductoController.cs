using EFCapaLogica;
using EFEntities;
using EFMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using PagedList;

namespace EFMVC.Controllers
{
    public class ProductoController : Controller
    {
        LogicaProductos logicaProductos = new LogicaProductos();

        // GET: Producto
        public ActionResult Index(int? page)
        {
            try
            {
                List<Products> listaProductos = logicaProductos.ObtenerTodos();
                List<ProductoView> listaVistaProducto = listaProductos.Select(p => new ProductoView
                {
                    Id = p.ProductID,
                    Nombre = p.ProductName,
                    CantidadPorUnidad = p.QuantityPerUnit,
                    PrecioUnitario = (decimal)p.UnitPrice
                }).ToList();

                int pageSize = 10;
                int pageNumber = page ?? 1;
  
                return View(listaVistaProducto.ToPagedList(pageNumber,pageSize));
            }
            catch (ExcepcionPersonalizadaMVC ep)
            {
                TempData["errorMessage"] = "Error: " + ep.Message;
                return RedirectToAction("Index", "Error");
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = "Error: " + e.Message;
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Producto/Ver/5
        public ActionResult Ver(int id)
        {
            try
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
            catch (ExcepcionPersonalizadaMVC ep)
            {
                TempData["errorMessage"] = "Error: " + ep.Message;
                return RedirectToAction("Index", "Error" );
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = "Error: " + e.Message;
                return RedirectToAction("Index", "Error");
            }
        }

        //GET: Producto/AltaYEdicion
        public ActionResult AltaYEdicion(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                try
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
                catch (ExcepcionPersonalizadaMVC ep)
                {
                    TempData["errorMessage"] = "Error: " + ep.Message;
                    return RedirectToAction("Index", "Error");
                }
                catch (Exception e)
                {
                    TempData["errorMessage"] = "Error: " + e.Message;
                    return RedirectToAction("Index", "Error");
                }
            }
        }

        //POST: Producto/AltaYEdicion
        [HttpPost]
        public ActionResult AltaYEdicion(ProductoView productoView)
        {
            if (ModelState.IsValid)
            {
                Products producto = new Products
                {
                    ProductID = productoView.Id,
                    ProductName = productoView.Nombre,
                    QuantityPerUnit = productoView.CantidadPorUnidad,
                    UnitPrice = productoView.PrecioUnitario
                };

                if (productoView.Id == 0) //Alta
                {
                    //En este método no se utiliza try-catch ya que la capa lógica maneja
                    //la excepción y deuelve false en caso de no haber podido guardar el productoView

                    bool resultadoOk = logicaProductos.Agregar(producto);
                    if (resultadoOk)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["errorMessage"] = "No se pudo guardar el producto. Verifique los datos ingresados.";
                        return RedirectToAction("Index", "Error");
                    }
                }
                else    //Editar
                {
                    //En este método no se utiliza try-catch ya que la capa lógica maneja
                    //la excepción y deuelve false en caso de no haber podido editar el productoView

                    bool resultadoOk = logicaProductos.Actualizar(producto);
                    if (resultadoOk)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["errorMessage"] = "No se pudo actualizar el producto. Verifique los datos ingresados.";
                        return RedirectToAction("Index", "Error");
                    }
                }
            }
            else
            {
                return View();
            }
            
        }
        // GET: Producto/Delete/5
        public ActionResult Borrar(int id)
        {
            //En este método no se utiliza try-catch ya que la capa lógica maneja
            //la excepción y deuelve false en caso de no haber podido eliminar el producto
            bool resultadoOk = logicaProductos.Borrar(id);
            if (resultadoOk)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "No se pudo eliminar el producto.";
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
