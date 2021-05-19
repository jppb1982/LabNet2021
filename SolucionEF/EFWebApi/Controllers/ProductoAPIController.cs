using EFCapaLogica;
using EFEntities;
using EFWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace EFWebApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProductoAPIController : ApiController
    {

        LogicaProductos logicaProductos = new LogicaProductos();

        // GET: api/ProductoAPI
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Products> listaProductosDB = logicaProductos.ObtenerTodos();
                List<Producto> listaProductosAPI = listaProductosDB.Select(p => new Producto
                {
                    Id = p.ProductID,
                    Nombre = p.ProductName,
                    CantidadPorUnidad = p.QuantityPerUnit,
                    PrecioUnitario = (decimal)p.UnitPrice
                }).ToList();

                dynamic listaProductosJson = JsonConvert.SerializeObject(listaProductosAPI);

                return Ok(listaProductosJson);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        // GET: api/ProductoAPI/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {

                Products producto = logicaProductos.BuscarProductoPorId(id);
                Producto productoAPI = new Producto
                {
                    Id = producto.ProductID,
                    Nombre = producto.ProductName,
                    CantidadPorUnidad = producto.QuantityPerUnit,
                    PrecioUnitario = (decimal)producto.UnitPrice
                };

                dynamic productoAPIJson = JsonConvert.SerializeObject(productoAPI);

                return Ok(productoAPIJson);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        // DELETE: api/ProductoAPI/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                logicaProductos.Borrar(id);
                return Ok("Se eliminó el producto exitosamente");
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Detalle: " + e.Message));
            }
        }


        [HttpPost]
        [ResponseType(typeof(Producto))]
        public IHttpActionResult Insert(Producto p)
        {

            try
            {
                logicaProductos.Agregar(new Products
                {
                    ProductName = p.Nombre,
                    QuantityPerUnit = p.CantidadPorUnidad,
                    UnitPrice = p.PrecioUnitario
                });
                return Ok("Se agregó el producto correctamente");

            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Detalle: " + e.Message));
            }
        }





        [HttpPut]
        [ResponseType(typeof(Producto))]
        public IHttpActionResult Actualizar(Producto p)
        {

            try
            {
                logicaProductos.Actualizar(new Products
                {
                    ProductID = p.Id,
                    ProductName = p.Nombre,
                    QuantityPerUnit = p.CantidadPorUnidad,
                    UnitPrice = p.PrecioUnitario
                });

                return Ok("El producto se actualizó correctamente");

            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Detalle: " + e.Message));
            }
        }

    }
}
