using E_Commerce.DbContext;
using Microsoft.EntityFrameworkCore;

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
            var result = _Context.Product
                .AsNoTracking()
                .Include(p => p.Category)
                .Where(p => p.Category.Name == category)
                .ToList();

            return result;
        }
        public List<Product> FilterByPrice(int price)
        {
            var result = _Context.Product
                .AsNoTracking()
               .Include(p => p.Category)
               .Where(p => p.NewPrice>0 && p.NewPrice<=price)
               .ToList();

            return result;

        }
        public List<Product> FilterByColor(string ValueColor)
        {
            var result = _Context.Product
                         .AsNoTracking()
                         .Include(x=>x.Category)
                         .Where(x => x.ProductVariants
                            .Any(x => x.color.Name == ValueColor))
                         .ToList();
            return result;

        }
        public List<Product> FilterBySize(string ValueSize)
        {
            var result = _Context.Product
                         .AsNoTracking()
                         .Include(x => x.Category)
                         .Where(x => x.ProductVariants
                            .Any(x => x.size.Name == ValueSize))
                         .ToList();
            return result;

        }
        public List<Product> AllProducts()
        {
            var result = _Context.Product
                .AsNoTracking()
                .Include(p => p.Category)
                .ToList();

            return result;
        }
        public List<string> AllColors()
        {
            var result = _Context.Color
                .AsNoTracking()
                .Select(x=>x.Name)
                .ToList();
            return result;
        }
        

        public List<string> AllSizess()
        {
            var result = _Context.Size
                .AsNoTracking()
               .Select(x => x.Name)
               .ToList();
            return result;
        }
              
        public Dictionary<string,int> AllCategories()
        {
            var result = _Context.Category
                .AsNoTracking()
                .Select(x => new { Name= x.Name,Count=x.Products.Count() })
                .ToDictionary(x => x.Name, x => x.Count);
            return result;
        }

        public List<Product> OrderType(string Type)
        {
            var List = AllProducts();
            if (Type == "Low to High")
            {
                return List.OrderBy(x => x.NewPrice).ToList();

            }
            else if (Type == "High to Low")
            {
                return List.OrderByDescending(x => x.NewPrice).ToList();

            }
            else
            {
                return List;
            }
        }

        public List<ProductVariant> GetProductById(int id)
        {
            var product = _Context.ProductVariant
                                  .AsNoTracking()
                                  .AsSplitQuery()
                                  .Include(x => x.color)
                                  .Include(x => x.size)
                                  .Include(x => x.product)
                                  .ThenInclude(x=>x.Category)
                          .Where(x => x.ProductId == id)
                          .ToList();
            return product;

        }

    }
}
