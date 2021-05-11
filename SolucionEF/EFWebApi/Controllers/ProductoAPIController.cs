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
using System.Web.Http.Description;

namespace EFWebApi.Controllers
{
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
            bool resultadoOk = logicaProductos.Borrar(id);

            if (resultadoOk)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }


        [HttpPost]
        [ResponseType(typeof(Producto))]
        public IHttpActionResult Insert(Producto p)
        {

            try
            {
                bool resultadoOk = logicaProductos.Agregar(new Products
                {
                    ProductName = p.Nombre,
                    QuantityPerUnit = p.CantidadPorUnidad,
                    UnitPrice = p.PrecioUnitario
                });

                if (resultadoOk)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                return NotFound();
            }

        }



        [HttpPut]
        [ResponseType(typeof(Producto))]
        public IHttpActionResult Actualizar(Producto p)
        {

            try
            {
                bool resultadoOk = logicaProductos.Actualizar(new Products
                {
                    ProductID = p.Id,
                    ProductName = p.Nombre,
                    QuantityPerUnit = p.CantidadPorUnidad,
                    UnitPrice = p.PrecioUnitario
                });

                if (resultadoOk)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                return NotFound();
            }

        }

    }
}
