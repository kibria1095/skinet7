using System.Text.Json;
using Core.Entities;

namespace infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsycn(StoreContext context)
        {

            if (!context.ProductBrands.Any())
            {
                
                var brandsData = File.ReadAllText("../infrastructure/Data/SeedData/brands.json");
            
                var brands  = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands); 
            }

            if (!context.ProductTypes.Any())
            {
                
                var typesData = File.ReadAllText("../infrastructure/Data/SeedData/types.json");
            
                var types  = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types); 
            }

            if (!context.Products.Any())
            {
                
                var productsData = File.ReadAllText("../infrastructure/Data/SeedData/products.json");
            
                var products  = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products); 
            }
                
            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();

        }
    }
}