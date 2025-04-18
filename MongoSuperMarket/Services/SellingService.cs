using AutoMapper;
using MongoSuperMarket.Dtos.SellingDtos;
using MongoSuperMarket.Entities;
using MongoSuperMarket.Settings;

namespace MongoSuperMarket.Services
{
    public class SellingService : GenericService<Selling, CreateSellingDto, UpdateSellingDto, GetByIdSellingDto, ResultSellingDto>, ISellingService
    {
        public SellingService(IMapper mapper, IDatabaseSettings databaseSettings)
            : base(mapper, databaseSettings, databaseSettings.SellingCollectionName)
        {
        }
    }
}
