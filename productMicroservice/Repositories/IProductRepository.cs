using productMicroservice.Models;

namespace productMicroservice.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void InsertProduct(Product product);
        void DeleteProduct(int product);
        void UpdateProduct(Product product);
        void Save();

    }
}
