using SharedModels;

namespace ProductService.Interfaces
{
    public interface IProductsRepository
    {
        public void AddProduct(Product product);
        public void UpdateProduct(int id, Product product);
        public void DeleteProduct(int id);
        public Product GetProductById(int id);
        public List<Product> GetProducts();

    }
}
