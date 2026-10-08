namespace E_Commerce.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }

        public int ColorId{ get; set; }

        public int SizeId { get; set; }

        public int ProductId { get; set; }

        public int Instock { get; set; }

        public Color color { get; set; }

        public Size size { get; set; }

        public Product product { get; set; }
    }
}
