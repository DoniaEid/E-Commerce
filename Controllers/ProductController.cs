using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        ProductBL ProductBL;
        public ProductController(ProductBL ProductBL)
        {
            this.ProductBL = ProductBL;
        }
        [HttpGet]
        public IActionResult Index()
        {
            FilterByViewModel filterByViewModel = new FilterByViewModel();
            filterByViewModel.Categories = ProductBL.AllCategories();
            filterByViewModel.Sizes = ProductBL.AllSizess();
            filterByViewModel.Colors = ProductBL.AllColors();

            return View(filterByViewModel);
        }

        [HttpPost]
        public IActionResult FilterByCategory(string category)
        {
            var products = ProductBL.FilterByCategory(category);
            return PartialView("PartialViewProduct", products);
        }

        [HttpGet]
        public IActionResult AllProduct()
        {
            var products = ProductBL.AllProducts();
            return PartialView("PartialViewProduct", products);
        }
    }
}
