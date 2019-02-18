using System.Collections.Generic;
using JBHiFi.Models;
using JBHiFi.Repositories;

namespace JBHiFi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Get a list of products filtered by the parameters passed in
        /// </summary>
        /// <param name="description">The description field to filter</param>
        /// <param name="model">The model field to filter</param>
        /// <param name="brand">The brand field to filter</param>
        /// <returns>A list of filtered products</returns>
        public List<Product> GetProducts(string description = "", string model = "", string brand = "")
        {
            return _productRepository.GetProducts(description, model, brand);
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="productId">The id of the product to retrieve</param>
        /// <returns>The product matching the id</returns>
        public Product GetProduct(int productId)
        {
            return _productRepository.GetProduct(productId);
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="product">The product to add</param>
        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        /// <summary>
        /// Update a product based on the id passed in
        /// </summary>
        /// <param name="product">The product to update to</param>
        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }

        /// <summary>
        /// Delete a product by the id passed in
        /// </summary>
        /// <param name="productId">The id of the product to delete</param>
        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
        }
    }
}