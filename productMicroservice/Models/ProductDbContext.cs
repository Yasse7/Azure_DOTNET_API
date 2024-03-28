using Microsoft.EntityFrameworkCore;

namespace productMicroservice.Models
{
    public class ProductDbContext : DbContext //interagir avec la base donnees effectuer des ops crud 
    {
        public DbSet<Product> Products { get; set;}
        public ProductDbContext(DbContextOptions<ProductDbContext>
            options) : base(options) { }
            
        //we have to migrate in the console : add-migration InitialMigrate & update-database : pour creer la table dans lable de donnees 

    }
}
