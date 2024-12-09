using System;
using System.Web.Http;
using Entities;
using BLL;

namespace Services.Controllers
{
    [RoutePrefix("api/Categoria")]
    public class CategoriaController : ApiController
    {
        private readonly CategoriesLogic _logic = new CategoriesLogic();

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] Categories category)
        {
            try
            {
                var createdCategory = _logic.Create(category);
                if (createdCategory != null)
                {
                    return Ok(createdCategory);
                }
                return BadRequest("La categoría ya existe.");
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
                var category = _logic.RetrieveById(id);
                if (category != null)
                {
                    return Ok(category);
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
        public IHttpActionResult Update([FromBody] Categories category)
        {
            try
            {
                if (_logic.Update(category))
                {
                    return Ok();
                }
                return BadRequest("La categoría no se pudo actualizar.");
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
                return BadRequest("La categoría no se pudo eliminar.");
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
                var categories = _logic.RetrieveAll();
                return Ok(categories);
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
                var categories = _logic.Filter(name);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
