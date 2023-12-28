using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    public class CrudDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public CrudDbContext(DbContextOptions<CrudDbContext> options) : base(options) { }
    }
}
