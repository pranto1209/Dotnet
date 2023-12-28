using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        CrudDbContext _context;
        public ProductsController(CrudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
             return _context.Products.ToList();
        }

        [HttpPost]
        public IActionResult AddProuct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }           
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.Products.Find(id);
            if (item is not null)
            {
                return Ok(item);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            try
            {
                if(id != product.ProductId)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                _context.Products.Update(product);
                _context.SaveChanges(true);
                return StatusCode(StatusCodes.Status200OK);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }  
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var item = _context.Products.Find(id);
            if (item is not null)
            {
                _context.Products.Remove(item);
                _context.SaveChanges();
                return Ok();
            }
            else return BadRequest();
        }
    }
}
