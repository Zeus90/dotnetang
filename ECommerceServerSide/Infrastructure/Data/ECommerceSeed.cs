using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ECommerceSeed
    {
        public static async Task SeedAsync(EcommerceContext context)
        {
            string path = "C:\\Users\\zeusk\\Downloads\\WebDev Projects\\Full Stack development Js Nodejs expressJs React\\Angular\\AspNetAngOnlineShop\\ECommerceServerSide\\Infrastructure\\Data\\SeedData";

            if (!context.ProductBrands.Any())
            {
                using var transaction = context.Database.BeginTransaction();
                var brandsData = File.ReadAllText($"{path}\\brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                foreach ( var brand in brands )
                {
                    context.ProductBrands.Add(brand);
                }

                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductBrands ON");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductBrands OFF");
                transaction.Commit();

            }

            if (!context.ProductTypes.Any())
            {
                using var transaction = context.Database.BeginTransaction();
                var typesData = File.ReadAllText($"{path}\\types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);

                foreach (var type in types)
                {
                    context.ProductTypes.Add(type);
                }

                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductTypes ON");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductTypes OFF");
                transaction.Commit();
            }

            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText($"{path}\\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }

            if (context.ChangeTracker.HasChanges()) 
            { 
                await context.SaveChangesAsync(); 
            }
        }
    }
}
