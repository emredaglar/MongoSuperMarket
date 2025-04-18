using MongoSuperMarket.Dtos.FeatureDtos;
using MongoSuperMarket.Entities;

namespace MongoSuperMarket.Services
{
    public interface IFeatureService : IGenericService<Feature, CreateFeatureDto, UpdateFeatureDto, GetByIdFeatureDto, ResultFeatureDto>
    {
    }
}
