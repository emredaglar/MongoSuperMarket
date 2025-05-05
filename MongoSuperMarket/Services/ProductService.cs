using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoSuperMarket.Dtos.ProductDtos;
using MongoSuperMarket.Dtos.SellingDtos;
using MongoSuperMarket.Entities;
using MongoSuperMarket.Settings;

namespace MongoSuperMarket.Services
{
    public class ProductService : GenericService<Product, CreateProductDto, UpdateProductDto, GetByIdProductDto, ResultProductDto>, IProductService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly ISellingService _sellingService;
        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings, ISellingService sellingService)
         : base(mapper, databaseSettings, databaseSettings.ProductCollectionName)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _sellingService = sellingService;
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

        public async Task<List<ResultProductDto>> SearchProductsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<ResultProductDto>();

            var products = await _collection.AsQueryable()
                .Where(product => product.ProductName.ToLower().Contains(query.ToLower()))
                .ToListAsync();

            var result = products.Select(product => new ResultProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductImage = product.ProductImage,
                ProductStock = product.ProductStock,
                CategoryId = product.CategoryId,
            }).ToList();

            return result;
        }
        public async Task<List<ResultSellingDto>> GetMostSellingProductsAsync()
        {
            var sellingProducts = await _sellingService.GetMostSellingProductsAsync();

            var result = sellingProducts.Select(selling => new ResultSellingDto
            {
                ProductId = selling.ProductId,
                ProductName = selling.ProductName,
                ProductImage = selling.ProductImage,
                ProductPrice = selling.ProductPrice
            }).ToList();

            return result;
        }
        public async Task<List<ResultProductDto>> GetProductsByCategoryIdAsync(string categoryId)
        {
            // İlk olarak ürünleri kategori id'sine göre al
            var products = await _collection.AsQueryable()
                                            .Where(product => product.CategoryId == categoryId)
                                            .ToListAsync();

            // Ürünlerin kategori adlarını ekleyebilmek için kategori verisini al
            var category = await _categoryCollection.AsQueryable()
                                                     .FirstOrDefaultAsync(c => c.CategoryId == categoryId);

            var result = products.Select(product => new ResultProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductImage = product.ProductImage,
                CategoryName = category != null ? category.CategoryName : "Kategori Yok"
            }).ToList();
            return result;
        }
    }
}