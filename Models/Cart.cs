namespace E_Commerce.Models
{
    public class Cart
    {

        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ?UserId { get; set; }

        public List<CartItems>cartItems { get; set; }

        public ApplicationUser ?User { get; set; }


    }
}
