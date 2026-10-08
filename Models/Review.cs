namespace E_Commerce.Models
{
    public class Review
    {
        public int Id { get; set; }


        public int ProductId { get; set; }

        public Product product { get; set; }

    }
}
