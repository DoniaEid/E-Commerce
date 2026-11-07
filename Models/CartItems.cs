namespace E_Commerce.Models
{
    public class CartItems
    {

        public int Id { get; set; }

        public int Quantity { get; set; }

        public int CartId { get; set; }

        public int ?ColorId { get; set; }

        public int ?SizeId { get; set; }

        public int ProductId { get; set; }

        public Product product { get; set; }

        public Color color { get; set; }

        public Size Size { get; set; }

        public Cart cart { get; set; }

    }
}
