using ProductService.Interfaces;
using SharedModels;

namespace ProductService.Services
{
    public class ProductsService : IProductService
    {
        IProductsRepository _productRepository;
        public ProductsService(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public void Delete(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public void Update(int id, Product product)
        {
            _productRepository.UpdateProduct(id, product);
        }

    }
}
