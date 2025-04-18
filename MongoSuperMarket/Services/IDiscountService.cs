using MongoSuperMarket.Dtos.DiscountDtos;
using MongoSuperMarket.Entities;

namespace MongoSuperMarket.Services
{
    public interface IDiscountService : IGenericService<Discount, CreateDiscountDto, UpdateDiscountDto, GetByIdDiscountDto, ResultDiscountDto>
    {
    }
}
