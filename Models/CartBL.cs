using E_Commerce.DbContext;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Models
{
    public class CartBL
    {
        AppDbContext _Context;
        public CartBL(AppDbContext _Context)
        {
            this._Context = _Context;
        }
        public int AddItemToCartWithOutUser( CartViewModel cartViewModel, int? CartId = null)
        {
            int cartId;

            // 1. Get or Create Cart
            Cart cart;

            if (CartId is null)
            {
                cart = new Cart();
                _Context.Cart.Add(cart);
                _Context.SaveChanges();
            }
            else
            {
                cart = _Context.Cart.FirstOrDefault(x => x.Id == CartId);

                if (cart == null)
                {
                    cart = new Cart();
                    _Context.Cart.Add(cart);
                    _Context.SaveChanges();
                }
            }

            cartId = cart.Id;

            // 2. Get Product, Color and Size
            var product = _Context.Product.FirstOrDefault(
                x => x.Name == cartViewModel.ProductName);

            var color = _Context.Color.FirstOrDefault(
                x => x.Name == cartViewModel.Color);

            var size = _Context.Size.FirstOrDefault(
                x => x.Name == cartViewModel.Size);

            if (product == null || color == null || size == null)
                return cartId;

            // 3. Check if Item already exists in Cart
            var cartItem = _Context.CartItems.FirstOrDefault(x =>
                x.CartId == cartId &&
                x.ProductId == product.Id &&
                x.ColorId == color.Id &&
                x.SizeId == size.Id
            );

            if (cartItem != null)
            {
                cartItem.Quantity += cartViewModel.Quantity;
            }
            else
            {
                CartItems newItem = new CartItems
                {
                    Quantity = 1,
                    CartId = cartId,
                    ProductId = product.Id,
                    ColorId = color.Id,
                    SizeId = size.Id
                };

                _Context.CartItems.Add(newItem);
            }

            _Context.SaveChanges();

            return cartId;
        }


        public List<CartDetailsViewModel> AllItemsCart(int CartId)
        {
            List<CartDetailsViewModel> x = _Context.CartItems
                   .Where(x => x.CartId == CartId)
                   .Select(Item =>
                        new CartDetailsViewModel
                        {
                            ProductName = Item.product.Name,

                            color = Item.color.Name,

                            size = Item.Size.Name,

                            Quantity = Item.Quantity,

                            Totalprice = (Item.product.NewPrice != null && Item.product.NewPrice > 0)
                            ? Item.product.NewPrice.Value * Item.Quantity
                            : Item.product.OldPrice * Item.Quantity,

                            ImageUrl=Item.product.ImageUrl
                        }
                     )
                   .ToList();

            return x;
        }

        public int ChangeQuantity(ChangeQuantityViewModel Item)
        {
            var product = _Context.CartItems.FirstOrDefault(
                x => x.product.Name == Item.ProductName
                && x.color.Name == Item.Color
                && x.Size.Name == Item.Size
            );

            if (product == null) return 0;

            int newQuantity = product.Quantity + Item.Delta;

            if (newQuantity >= 1)
            {
                product.Quantity = newQuantity;
                _Context.SaveChanges();
            }

            return product.Quantity;
        }


       public void DeleteItem(string ProductName, string color, string size)
        {
            var product = _Context.CartItems.FirstOrDefault(
              x => x.product.Name == ProductName
              && x.color.Name == color
              && x.Size.Name == size
             );

            _Context.Remove(product);
            _Context.SaveChanges();
        }
    }
}
