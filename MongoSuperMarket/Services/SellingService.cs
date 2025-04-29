using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoSuperMarket.Dtos.SellingDtos;
using MongoSuperMarket.Entities;
using MongoSuperMarket.Settings;

namespace MongoSuperMarket.Services
{
    public class SellingService : GenericService<Selling, CreateSellingDto, UpdateSellingDto, GetByIdSellingDto, ResultSellingDto>, ISellingService
    {
        private readonly IMongoCollection<Product> _productCollection;
        public SellingService(IMapper mapper, IDatabaseSettings databaseSettings, IMongoCollection<Product> productCollection)
            : base(mapper, databaseSettings, databaseSettings.SellingCollectionName)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }

        public async Task<List<ResultSellingDto>> GetAllSellingWithProductNameAsync()
        {
            var query = await _collection.AsQueryable()
             .Join(
                 _productCollection.AsQueryable(),
                 product => product.ProductId,
                 selling => selling.ProductId,
                 (selling, product) => new ResultSellingDto
                 {
                     ProductId = product.ProductId,
                     Count = selling.Count,
                     SellingDate = selling.SellingDate,
                     SellingId = selling.SellingId,
                     TotalPrice = selling.TotalPrice,
                     ProductName = product.ProductName
                 }
             ).ToListAsync();

            return query;
        }
    }
}
