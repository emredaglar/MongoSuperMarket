using AutoMapper;
using MongoSuperMarket.Dtos.FeatureDtos;
using MongoSuperMarket.Entities;
using MongoSuperMarket.Settings;

namespace MongoSuperMarket.Services
{
    public class FeatureService : GenericService<Feature, CreateFeatureDto, UpdateFeatureDto, GetByIdFeatureDto, ResultFeatureDto>, IFeatureService
    {
        public FeatureService(IMapper mapper, IDatabaseSettings databaseSettings, string collectionName)
            : base(mapper, databaseSettings, databaseSettings.FeatureCollectionName)
        {
        }
    }
}
