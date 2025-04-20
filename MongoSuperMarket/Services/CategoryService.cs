using AutoMapper;
using MongoSuperMarket.Dtos.CategoryDtos;
using MongoSuperMarket.Entities;
using MongoSuperMarket.Settings;

namespace MongoSuperMarket.Services
{
    public class CategoryService : GenericService<Category, CreateCategoryDto, UpdateCategoryDto, GetByIdCategoryDto, ResultCategoryDto>, ICategoryService
    {
        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings) : base(mapper, databaseSettings, databaseSettings.CategoryCollectionName)
        {
        }
    }
}
