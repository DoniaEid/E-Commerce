namespace E_Commerce.Models
{
    public class Color
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductVariant> productVariant { get; set; }
    }
}
