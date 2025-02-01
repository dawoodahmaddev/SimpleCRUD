using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.Models;
using SimpleCRUD.Service;

namespace SimpleCRUD.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var products = _productService.AllProducts();
            return View(products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            _productService.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id){
            var product = _productService.FindProduct(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product){
            _productService.UpdateProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id){
            _productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
