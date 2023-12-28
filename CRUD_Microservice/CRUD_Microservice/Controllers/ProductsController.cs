using CRUD_Microservice.Models;
using CRUD_Microservice.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Transactions;

namespace CRUD_Microservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Read()
        {
            var products = _repository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            var products = _repository.GetProductById(id);
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            try
            {
                _repository.InsertProduct(product);
                return Created("", product);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

     
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            try
            {
                if (product.Id == 0)
                {
                    return BadRequest("Id is missing!");
                }
                bool isUpdate = _repository.UpdateProduct(id, product);
                if (isUpdate)
                {
                    return Ok(product);
                }
                return BadRequest("Post updated failed!");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var post = _repository.GetProductById(id);
                if (post == null)
                {
                    return NotFound();
                }
                bool isDelete = _repository.DeleteProduct(id);
                if (isDelete)
                {                   
                    return Ok("Post has been deleted!");
                }
                return BadRequest("Post deletd failed!");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
