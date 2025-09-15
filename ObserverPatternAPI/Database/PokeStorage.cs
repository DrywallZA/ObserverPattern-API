using MongoDB.Driver;
using ObserverPatternAPI.Models.PokeModel;

namespace ObserverPatternAPI.Database
{
    public class PokeStorage
    {
        const string dbConnectionString = "mongodb://localhost:27017/";
        private readonly MongoClient _mongodbClient = new MongoClient();

        public PokeStorage()
        {
            _mongodbClient = new MongoClient(dbConnectionString);
        }

        public void SavePokemon(PokeModel pokeModel)
        {
            try
            {
                //Change your DB and collection name as required
                var collection = SetupCollection<PokeModel>("local", "pokemon");

                collection.InsertOne(pokeModel);
            }
            catch (Exception ex)
            {
                throw new MongoException($"Can't connect to Mongo Db: {ex.Message}");
            }
        }

        private IMongoCollection<T> SetupCollection<T>(string databaseName, string collectionName)
        {
            var database = _mongodbClient.GetDatabase(databaseName);

            return database.GetCollection<T>(collectionName);
        }
    }
}