using CRUD_Microservice.Models;

namespace CRUD_Microservice.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product? GetProductById(int productId);
        void InsertProduct(Product product);
        bool DeleteProduct(int productId);
        bool UpdateProduct(int id, Product product);
        void Save();
    }
}
