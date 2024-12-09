using System;
using System.Collections.Generic;
using System.Web.Http;
using Entities;
using BLL;

namespace Services.Controllers
{
    [RoutePrefix("api/Producto")]
    public class ProductoController : ApiController
    {
        private readonly ProductsLogic _logic = new ProductsLogic();

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] Products product)
        {
            try
            {
                var createdProduct = _logic.Create(product);
                if (createdProduct != null)
                {
                    return Ok(createdProduct);
                }
                return BadRequest("El producto ya existe.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult RetrieveById(int id)
        {
            try
            {
                var product = _logic.RetrieveById(id);
                if (product != null)
                {
                    return Ok(product);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Update([FromBody] Products product)
        {
            try
            {
                if (_logic.Update(product))
                {
                    return Ok();
                }
                return BadRequest("El producto no se pudo actualizar.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (_logic.Delete(id))
                {
                    return Ok();
                }
                return BadRequest("El producto no se pudo eliminar.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult RetrieveAll()
        {
            try
            {
                var products = _logic.RetrieveAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("filter")]
        public IHttpActionResult Filter([FromUri] string name)
        {
            try
            {
                var products = _logic.Filter(name);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
