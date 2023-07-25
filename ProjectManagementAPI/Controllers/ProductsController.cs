using Microsoft.AspNetCore.Mvc;
using Repositories;
using System.Collections;
using BusinessObjects;
using System.Collections.Generic;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => repository.GetProducts();
        
        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            repository.SaveProduct(product);
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            var p = repository.GetProductById(id);
            if (p == null)
            {
                return NotFound();
            }
            repository.DeleteProduct(p);
            return NoContent();
        }

        [HttpPut("id")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var p = repository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            repository.UpdateProduct(product);
            return NoContent();
        }

    }
}
