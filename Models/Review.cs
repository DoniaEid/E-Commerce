namespace E_Commerce.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string review { get; set; }

        public int NumberStars { get; set; }

        public string ?UserId { get; set; }

        public int ProductId { get; set; }

        public Product product { get; set; }

        public ApplicationUser user{ get; set; }
    }
}
