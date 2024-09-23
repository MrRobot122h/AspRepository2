using ProductService.Interfaces;
using SharedModels;


namespace ProductService.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private static List<Product> _products = new List<Product>();
        private int nextProductId = 1;
        public ProductsRepository() { }

        public void AddProduct(Product product)
        {
            if (_products.Any(x => x.Name == product.Name))
            {
                throw new InvalidOperationException("Продукт з таким назвою вже існує.");
            }

            product.Id = nextProductId++;
            _products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new InvalidOperationException($"Продукт з ID {id} не знайдений.");
            }

            _products.Remove(product);
        }

        public Product GetProductById(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new InvalidOperationException($"Продукт з ID {id} не знайдений.");
            }

            return product;
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public void UpdateProduct(int id, Product newProduct)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new InvalidOperationException($"Продукт з ID {id} не знайдений.");
            }
            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
        }
    }
}
