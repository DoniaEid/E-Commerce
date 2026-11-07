namespace E_Commerce.Models
{
    public class CartViewModel
    {

        public string ProductName { get; set; }
       
       public int Quantity { get; set; }

       public string Color { get; set; }

       public  string Size { get; set; }

       public decimal? Price { get; set; }
    }
}
