using CRUD_Microservice.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Microservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CrudMicroserviceDbContext _context;

        public ProductRepository(CrudMicroserviceDbContext context)
        {
            _context = context;
        }

        public bool DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                Save();
                return true;
            }
            return false;
        }

        public Product? GetProductById(int productId)
        {
            var product = _context.Products.Find(productId);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _context.Add(product);
            Save();
        }

        public bool UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return false;
            }
            _context.Products.Update(product);
            _context.SaveChanges(true);
            return true;
        }
        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
