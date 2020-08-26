using Domain.Entity;
using Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IBaseRepository<Product> _productRepository;

        public ProductController( IBaseRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("{idProduct}")]
        public ActionResult<Product> Get(int IdProduct)
        {
            try
            {
                var product = _productRepository.GetById(IdProduct);
                if (product != null)
                {
                    return Ok(product);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            try
            {
                var products = _productRepository.GetAll();
                if (products.Count() > 0)
                {
                    return Ok(products);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                if (_productRepository.Insert(product))
                {
                    return Ok();
                }
                return BadRequest("Não foi possível inserir o produto");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{idProduct}")]
        public IActionResult Delete(int idProduct)
        {
            try
            {
                var product = _productRepository.GetById(idProduct);
                if(product == null)
                {
                    return NotFound();
                }

                if (_productRepository.Delete(product))
                {
                    return Ok();
                }
                return BadRequest("Não foi possível excluir o produto");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{idProduct}")]
        public IActionResult Put([FromBody] Product product)
        {
            try
            {
                if (_productRepository.Update(product))
                {
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
