using Microsoft.EntityFrameworkCore;

namespace CRUD_Microservice.Models
{
    public class CrudMicroserviceDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        
        public CrudMicroserviceDbContext(DbContextOptions<CrudMicroserviceDbContext> options) : base(options) { }
    }
}
