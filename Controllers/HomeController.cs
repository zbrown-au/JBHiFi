using System.Collections.Generic;
using System.Web.Http.Results;
using System.Web.Mvc;
using JBHiFi.Models;

namespace JBHiFi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "JB Hi-Fi Web API";

            var products = new ProductsController().Get() as OkNegotiatedContentResult<List<Product>>;

            return View(products.Content);
        }
    }
}
