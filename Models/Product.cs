namespace E_Commerce.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? NewPrice { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

       
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<ProductVariant> ProductVariants { get; set; }

        public List<Review> Reviews { get; set; }
    }
}