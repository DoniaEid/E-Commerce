namespace E_Commerce.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }

        public decimal? NewPrice { get; set; }

        public decimal? OldPrice { get; set; }

        public string Description { get; set; }
        public int id { get; set; }
        public string CategoryName { get; set; }

        public long NumberInStock { get; set; }

        public List<ProductVariant>? ProductVariant { get; set; }

        public List<string> ?colors{get;set;}

        public List<string>? sizes { get; set; }

        public List<Review>? Reviews { get; set; }

    }
}
