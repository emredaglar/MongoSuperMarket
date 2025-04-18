using AutoMapper;
using MongoSuperMarket.Dtos.DiscountDtos;
using MongoSuperMarket.Entities;
using MongoSuperMarket.Settings;

namespace MongoSuperMarket.Services
{
    public class DiscountService : GenericService<Discount, CreateDiscountDto, UpdateDiscountDto, GetByIdDiscountDto, ResultDiscountDto>, IDiscountService
    {
        public DiscountService(IMapper mapper, IDatabaseSettings databaseSettings)
            : base(mapper, databaseSettings, databaseSettings.DiscountCollectionName)
        {
        }
    }
}
