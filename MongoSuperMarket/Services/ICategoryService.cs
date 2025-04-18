using MongoSuperMarket.Dtos.CategoryDtos;
using MongoSuperMarket.Entities;

namespace MongoSuperMarket.Services
{
    public interface ICategoryService: IGenericService<Category, CreateCategoryDto, UpdateCategoryDto, GetByIdCategoryDto, ResultCategoryDto>
    {
    }
}