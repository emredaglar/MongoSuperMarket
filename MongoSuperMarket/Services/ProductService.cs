using AutoMapper;
using MongoDB.Driver;
using MongoSuperMarket.Dtos.ProductDtos;
using MongoSuperMarket.Entities;
using MongoSuperMarket.Settings;

namespace MongoSuperMarket.Services
{
    public class ProductService : GenericService<Product, CreateProductDto, UpdateProductDto, GetByIdProductDto, ResultProductDto>, IProductService
    {
        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
            : base(mapper, databaseSettings, databaseSettings.ProductCollectionName)
        {
        }

        public async Task<List<ResultProductDto>> GetAllProductWithCategoryAsync()
        {
            // 1. MongoDB bağlantılarını hazırla
            var productCollection = _database.GetCollection<Product>(_collectionName);
            var categoryCollection = _database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);

            // 2. Tüm ürünleri ve kategorileri çek
            var products = await productCollection.Find(_ => true).ToListAsync();
            var categories = await categoryCollection.Find(_ => true).ToListAsync();

            // 3. Ürünleri kategori adıyla eşleştirerek ResultProductDto oluştur
            var result = products.Select(p =>
            {
                var category = categories.FirstOrDefault(c => c.CategoryId == p.CategoryId);
                return new ResultProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    ProductPrice = p.ProductPrice,
                    ProductStock = p.ProductStock,
                    ProductImage = p.ProductImage,
                    CategoryName = category?.CategoryName ?? "Kategori Yok"
                };
            }).ToList();

            return result;
        }
    }
}
