using MongoDB.Driver;
using MongoSuperMarket.Settings;

namespace MongoSuperMarket.Services
{
    public abstract class BaseMongoService<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;
        protected readonly IMongoDatabase _database;
        protected readonly IDatabaseSettings _databaseSettings;
        protected readonly string _collectionName;

        protected BaseMongoService(IDatabaseSettings databaseSettings, string collectionName)
        {
            _databaseSettings = databaseSettings;
            var client = new MongoClient(databaseSettings.ConnectionString);
            _database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = _database.GetCollection<T>(collectionName);
            _collectionName = collectionName;
        }
    }
}
