using Microsoft.EntityFrameworkCore;
using productMicroservice.Models;
using System.Linq;

namespace productMicroservice.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbcontext; 
        public ProductRepository(ProductDbContext productDbContext)
        {
            _dbcontext = productDbContext;
        }
        public void DeleteProduct(int productId)
        {
            var product = _dbcontext.Products.Find(productId);
            _dbcontext.Products.Remove(product);
            Save();
        }

        public Product GetProductById(int id)
        {
            return _dbcontext.Products.Find(id);
            Save();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbcontext.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _dbcontext.Add(product);
            Save();
        }

        public void Save()
        {
           _dbcontext.SaveChanges();
        }
        
        public void UpdateProduct(Product product)
        {
            _dbcontext.Entry(product).State = EntityState.Modified;
            Save();
        }
    }
}
