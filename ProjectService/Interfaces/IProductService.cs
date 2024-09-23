using SharedModels;

namespace ProductService.Interfaces
{
    public interface IProductService
    {
        public void Add(Product product);
        public void Update(int id, Product product);
        public void Delete(int id);
        public Product GetProduct(int id);
        public List<Product> GetProducts();
    }
}
