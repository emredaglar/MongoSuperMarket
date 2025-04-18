using MongoSuperMarket.Dtos.SellingDtos;
using MongoSuperMarket.Entities;

namespace MongoSuperMarket.Services
{
    public interface ISellingService : IGenericService<Selling, CreateSellingDto, UpdateSellingDto, GetByIdSellingDto, ResultSellingDto>
    {
    }
}
