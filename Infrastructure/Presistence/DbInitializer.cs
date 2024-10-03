


namespace Persistence
{
    public class DbInitializer : IDbInitializer
    {
        private readonly StoreContext _storeContext;

        public DbInitializer(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task InitializeAsync()
        {
            try 
            {
                //Create DB if it does not exist and apply and pending migrations
                if (_storeContext.Database.GetPendingMigrations().Any())
                    await _storeContext.Database.MigrateAsync();

                //Apply Data Seeding
                if (!_storeContext.ProductTypes.Any())
                {
                    //Read types from files as string
                    var TypesData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistence\Data\Seeding\types.json");

                    //Transform'em into C# objects
                    var types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                    //Add to DB and save changes
                    if (types != null && types.Any())
                    {
                        await _storeContext.ProductTypes.AddRangeAsync(types);
                        await _storeContext.SaveChangesAsync();
                    }
                }

                if (!_storeContext.ProductBrands.Any())
                {
                    //Read types from files as string
                    var BrandsData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistence\Data\Seeding\brands.json");

                    //Transform'em into C# objects
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);

                    //Add to DB and save changes
                    if (brands != null && brands.Any())
                    {
                        await _storeContext.ProductBrands.AddRangeAsync(brands);
                        await _storeContext.SaveChangesAsync();
                    }
                }

                if (!_storeContext.Products.Any())
                {
                    //Read types from files as string
                    var ProductsData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistence\Data\Seeding\products.json");

                    //Transform'em into C# objects
                    var products = JsonSerializer.Deserialize<List<Product>>(ProductsData);

                    //Add to DB and save changes
                    if (products != null && products.Any())
                    {
                        await _storeContext.Products.AddRangeAsync(products);
                        await _storeContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
