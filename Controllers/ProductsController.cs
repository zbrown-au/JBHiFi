using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using JBHiFi.Models;
using JBHiFi.Services;
using Autofac;

namespace JBHiFi.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductService _productService;

        public ProductsController()
        {
            IContainer container = IoCBuilder.Build();
            _productService = container.Resolve<IProductService>();
        }

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/products
        [HttpGet]
        public IHttpActionResult Get(string description = "", string model = "", string brand = "")
        {
            List<Product> products = _productService.GetProducts();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // GET api/products/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Product product = _productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST api/products
        [HttpPost]
        public IHttpActionResult Post([FromBody]Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid product record");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _productService.AddProduct(product);
            }
            catch (Exception e)
            {
                var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(e.Message)
                };
                throw new HttpResponseException(message);
            }
            
            return Ok();       
        }

        // PUT api/products/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid product record");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                product.Id = id;
                _productService.UpdateProduct(product);
            }
            catch (Exception e)
            {
                var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(e.Message)
                };
                throw new HttpResponseException(message);
            }
            
            return Ok();
        }

        // DELETE api/products/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);

            return Ok();
        }
    }
}
