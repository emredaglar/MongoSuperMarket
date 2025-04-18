
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoSuperMarket.Settings;

namespace MongoSuperMarket.Services
{
    public class GenericService<TEntity, TCreateDto, TUpdateDto, TGetByIdDto, TResultDto>
    : BaseMongoService<TEntity>, IGenericService<TEntity, TCreateDto, TUpdateDto, TGetByIdDto, TResultDto>
    where TEntity : class
    {
        private readonly IMapper _mapper;
        public GenericService(IMapper mapper, IDatabaseSettings databaseSettings, string collectionName) : base(databaseSettings, collectionName)
        {
            _mapper = mapper;
        }

        public async Task CreateAsync(TCreateDto createDto)
        {
            var entity = _mapper.Map<TEntity>(createDto);
            await _collection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            if (ObjectId.TryParse(id, out var objectId))
            {
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                await _collection.DeleteOneAsync(filter);
            }
            else
            {
                throw new ArgumentException("Geçersiz ObjectId formatı.", nameof(id));
            }
        }

        public async Task<List<TResultDto>> GetAllAsync()
        {
            var entities = await _collection.Find(x => true).ToListAsync();
            return _mapper.Map<List<TResultDto>>(entities);
        }

        public async Task<TGetByIdDto> GetByIdAsync(string id)
        {
            // Gelen id string'inin geçerli bir ObjectId formatında olup olmadığını kontrol ediyoruz
            if (ObjectId.TryParse(id, out var objectId))
            {
                // MongoDB'deki "_id" alanı ile eşleşen belgeyi filtreliyoruz
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);

                // Bu filtreye uyan ilk belgeyi veritabanından çekiyoruz
                var entity = await _collection.Find(filter).FirstOrDefaultAsync();

                // Veritabanından gelen entity'yi AutoMapper ile DTO'ya çeviriyoruz
                return _mapper.Map<TGetByIdDto>(entity);
            }
            else
            {
                // Eğer id geçerli bir ObjectId değilse, hata fırlatıyoruz
                throw new ArgumentException("Geçersiz ObjectId formatı.", nameof(id));
            }
        }


        public async Task UpdateAsync(TUpdateDto updateDto)
        {
            
            var idProperty = typeof(TUpdateDto).GetProperties()
                                               .FirstOrDefault(p => p.Name.EndsWith("Id",StringComparison.OrdinalIgnoreCase));

            if (idProperty != null)
            {
                var idValue = idProperty.GetValue(updateDto)?.ToString();
                if (!string.IsNullOrEmpty(idValue))
                {
                    
                    var objectId = ObjectId.Parse(idValue);

                 
                    var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                    var entity = _mapper.Map<TEntity>(updateDto);
                    await _collection.ReplaceOneAsync(filter, entity);
                }
            }
            else
            {
                throw new ArgumentException("Id alanı bulunamadı.", nameof(updateDto));
            }
        }
    }
}
