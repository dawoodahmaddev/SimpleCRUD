using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.Models;
using SimpleCRUD.Service;

namespace SimpleCRUD.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            var products = ProductService.AllProducts();
            return View(products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            ProductService.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id){
            var product = ProductService.FindProduct(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product){
            ProductService.UpdateProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id){
            ProductService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
