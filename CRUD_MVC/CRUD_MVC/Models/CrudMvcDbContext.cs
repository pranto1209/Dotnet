using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC.Models
{
    public class CrudMvcDbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        /*
        public CrudMvcDbContext(DbContextOptions<CrudMvcDbContext> options) : base(options) { }
        */
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MASUM-PRANTO\\SQLEXPRESS;Database=CrudMvcDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
