using AutoMapper;
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
    }
}
