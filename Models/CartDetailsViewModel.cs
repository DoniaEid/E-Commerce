namespace E_Commerce.Models
{
    public class CartDetailsViewModel
    {
        public string ProductName { get; set; }

        public string color{ get; set; }

        public string size { get; set; }

        public int Quantity { get; set; }

        public decimal? Totalprice { get; set; }

        public string ImageUrl{ get; set; }
    }
}
