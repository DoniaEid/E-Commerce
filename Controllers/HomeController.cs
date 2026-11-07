using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        ProductBL productBL;
        public HomeController(ProductBL productBL)
        {
            this.productBL = productBL;
        }

        public IActionResult Index()
        {
            var x = productBL.AllCategories();

            HomeViewModel homeViewModel = new HomeViewModel();

            List<string> All = new List<string>();

            foreach (var item in x)
            {
                All.Add(item.Key);
            }

            homeViewModel.Categories = All;

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

     

        public IActionResult FindProductsByCategory(string category)
        {
            return RedirectToAction("Index", "Product", new {category});

        }








    }
}
