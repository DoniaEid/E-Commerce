namespace E_Commerce.Models
{
    public class CartItems
    {

        public int Id { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public Product product { get; set; }

        public Cart cart { get; set; }

    }
}
