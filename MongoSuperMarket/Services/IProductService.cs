using MongoSuperMarket.Dtos.ProductDtos;
using MongoSuperMarket.Entities;

namespace MongoSuperMarket.Services
{
    public interface IProductService : IGenericService<Product, CreateProductDto, UpdateProductDto, GetByIdProductDto, ResultProductDto>
    {
    }
}
