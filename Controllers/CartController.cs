using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    public class CartController : Controller
    {
        CartBL cartBL;

        public CartController(CartBL cartBL)
        {
            this.cartBL = cartBL;
        }

        public IActionResult Index()
        {
            string cartIdCookie = HttpContext.Request.Cookies["CartId"];

            if (cartIdCookie != null && int.TryParse(cartIdCookie, out int cartId))
            {
                List<CartDetailsViewModel> items = cartBL.AllItemsCart(cartId);

                if (items == null || !items.Any())
                {
                    return View(new List<CartDetailsViewModel>()); 
                }

                return View(items);
            }
            else
            {
                return View(new List<CartDetailsViewModel>());
            }
        }


        public IActionResult AddToCart(CartViewModel cartViewModel)
        {
            // First Enter: Create a new Cart
            if (HttpContext.Request.Cookies["CartId"] == null)
            {
                int cartId = cartBL.AddItemToCartWithOutUser(cartViewModel);

                HttpContext.Response.Cookies.Append(
                    "CartId",
                    cartId.ToString(),
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(30),
                        HttpOnly = true,
                        Secure = Request.IsHttps,
                        SameSite = SameSiteMode.Lax
                    }
                );
            }
            else
            {
                int cartId = int.Parse(
                    HttpContext.Request.Cookies["CartId"]
                );

                cartBL.AddItemToCartWithOutUser(cartViewModel, cartId);
            }

            return RedirectToAction("Index", "Product");
        }

        public IActionResult ClearCartCookie()
        {
            HttpContext.Response.Cookies.Delete("CartId");

            return RedirectToAction("Index", "Product");
        }

       
        [HttpPost]
        public IActionResult ChangeQuantityProduct(ChangeQuantityViewModel Item)
        {
            int newQuantity = cartBL.ChangeQuantity(Item);
            return Json(newQuantity);
        }

        [HttpGet]
        public IActionResult DeleteItemInCart(string ProductName,string color,string size)
        {
            cartBL.DeleteItem(ProductName, color, size);
            return RedirectToAction("Index");
        }



    }
}
