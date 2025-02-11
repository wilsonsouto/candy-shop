using CandyShop.Models;

namespace CandyShop.Controllers
{
    public interface IProductController
    {
        List<Product> GetProducts();

        void AddProduct(Product product);

        // void AddProducts(Lis<Product> products);

        void DeleteProduct(Product product);

        void UpdateProduct(Product product);
    }
}
