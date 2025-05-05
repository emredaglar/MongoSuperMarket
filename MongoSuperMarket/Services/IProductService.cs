using MongoSuperMarket.Dtos.ProductDtos;
using MongoSuperMarket.Dtos.SellingDtos;
using MongoSuperMarket.Entities;

namespace MongoSuperMarket.Services
{
    public interface IProductService : IGenericService<Product, CreateProductDto, UpdateProductDto, GetByIdProductDto, ResultProductDto>
    {
        Task<List<ResultProductDto>> GetAllProductWithCategoryAsync();
        Task<List<ResultProductDto>> SearchProductsAsync(string query);
        Task<List<ResultSellingDto>> GetMostSellingProductsAsync();
        Task<List<ResultProductDto>> GetProductsByCategoryIdAsync(string categoryId);
    }
}
