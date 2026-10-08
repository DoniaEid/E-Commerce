using E_Commerce.DbContext;

namespace E_Commerce.Models
{
    public class ProductBL
    {
        AppDbContext _Context;
        public ProductBL(AppDbContext _Context)
        {
            this._Context = _Context;
        }

        public List<Product> FilterByCategory(string category)
        {
           var result= _Context.Product
                .Where(p => p.Category.Name == category)
                .ToList();
            return result;

        }
        public List<string> AllColors()
        {
            var result = _Context.Color
                .Select(x=>x.Name)
                .ToList();
            return result;
        }
        public List<Product> AllProducts()
        {
            var result = _Context.Product
                .ToList();
            return result;
        }

        public List<string> AllSizess()
        {
            var result = _Context.Size
               .Select(x => x.Name)
               .ToList();
            return result;
        }
              
        public Dictionary<string,int> AllCategories()
        {
            var result = _Context.Category
                .Select(x => new { Name= x.Name,Count=x.Products.Count() })
                .ToDictionary(x => x.Name, x => x.Count);
            return result;
        }

    }
}
