using System;
using System.Collections.Generic;
using System.Linq;
using JBHiFi.Models;

namespace JBHiFi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Get a list of products filtered by the parameters passed in
        /// </summary>
        /// <param name="description">The description field to filter</param>
        /// <param name="model">The model field to filter</param>
        /// <param name="brand">The brand field to filter</param>
        /// <returns>A list of filtered products</returns>
        public List<Product> GetProducts(string description = "", string model = "", string brand = "")
        {
            // AppCache used for in-memory persistence
            List<Product> products = Cache.AppCache.ContainsKey("Products") ? (List<Product>)Cache.AppCache["Products"] : new List<Product>();

            IQueryable<Product> query = products.AsQueryable();

            // Filter results
            if (!string.IsNullOrWhiteSpace(description))
            {
                query = query.Where(x => description.Equals(x.Description, StringComparison.CurrentCultureIgnoreCase));
            }
            
            if (!string.IsNullOrWhiteSpace(model))
            {
                query = query.Where(x => model.Equals(x.Model, StringComparison.CurrentCultureIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(brand))
            {
                query = query.Where(x => brand.Equals(x.Brand, StringComparison.CurrentCultureIgnoreCase));
            }
                        
            return query.ToList();
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="productId">The id of the product to retrieve</param>
        /// <returns>The product matching the id</returns>
        public Product GetProduct(int productId)
        {
            var products = GetProducts();

            return products.FirstOrDefault(x => x.Id == productId);
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="product">The product to add</param>
        public void AddProduct(Product product)
        {
            var products = GetProducts();

            int newProductId = products.Any() ? products.Max(x => x.Id) + 1 : 1;
            product.Id = newProductId;

            products.Add(product);

            SaveProducts(products);
        }

        /// <summary>
        /// Update a product based on the id passed in
        /// </summary>
        /// <param name="product">The product to update to</param>
        public void UpdateProduct(Product product)
        {
            var products = GetProducts();
            var productToUpdate = products.FirstOrDefault(x => x.Id == product.Id);

            if (productToUpdate != null)
            {
                productToUpdate.Description = product.Description;
                productToUpdate.Model = product.Model;
                productToUpdate.Brand = product.Brand;

                SaveProducts(products);
            }
        }

        /// <summary>
        /// Delete a product by the id passed in
        /// </summary>
        /// <param name="productId">The id of the product to delete</param>
        public void DeleteProduct(int productId)
        {
            var products = GetProducts();
            var productToRemove = products.FirstOrDefault(x => x.Id == productId);

            if (productToRemove != null)
            {
                products.Remove(productToRemove);

                SaveProducts(products);
            }
        }
        
        /// <summary>
        /// Store list of products in memory
        /// </summary>
        /// <param name="products">List of products to store</param>
        public void SaveProducts(List<Product> products)
        {
            // AppCache used for in-memory persistence
            if (Cache.AppCache.ContainsKey("Products"))
            {
                Cache.AppCache["Products"] = products;
            }
            else
            {
                Cache.AppCache.Add("Products", products);
            }
        }
    }
}