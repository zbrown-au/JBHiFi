using System.Collections.Generic;
using JBHiFi.Models;

namespace JBHiFi.Services
{
    public interface IProductService
    {
        List<Product> GetProducts(string description = "", string model = "", string brand = "");

        Product GetProduct(int productId);

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int productId);
    }
}
