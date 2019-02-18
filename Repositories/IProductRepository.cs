using System.Collections.Generic;
using JBHiFi.Models;

namespace JBHiFi.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts(string description = "", string model = "", string brand = "");

        Product GetProduct(int productId);

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int productId);

        void SaveProducts(List<Product> products);
    }
}
