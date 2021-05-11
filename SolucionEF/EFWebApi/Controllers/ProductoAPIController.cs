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

            if (resultadoOk){
                return Ok();
            } else{
                return NotFound();
            }
            
        }
    }
}
