namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Price = 1999, Stock = 100 },
            new Product { Id = 2, Name = "Mouse", Price = 99, Stock = 150 },
            new Product { Id = 3, Name = "Keyboard", Price = 299, Stock = 120 }
        };
        public List<Product> GetAll() => _products;

        public void Add(Product newProduct)=>_products.Add(newProduct);

        public void Remove(int id)
        {
            var hasProduct=_products.FirstOrDefault(x => x.Id == id);
            if (hasProduct==null)
            {
                throw new Exception($"Bu id ({id})'ye sahip ürün bulunmamaktadır.");
            }

            _products.Remove(hasProduct);
        }

        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id);
            if (hasProduct == null)
            {
                throw new Exception($"Bu id ({updateProduct.Id})'ye sahip ürün bulunmamaktadır.");
            }

            hasProduct.Name = updateProduct.Name;
            hasProduct.Price = updateProduct.Price;
            hasProduct.Stock=updateProduct.Stock;

            var index=_products.FindIndex(x=>x.Id == updateProduct.Id);
            _products[index] = hasProduct;
        }
    }
}
