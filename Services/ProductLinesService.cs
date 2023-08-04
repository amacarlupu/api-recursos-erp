using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SupportPageApi.Models;

namespace SupportPageApi.Services
{
    public class ProductLinesService
    {
        private readonly IMongoCollection<ProductLines> _productLinesCollection; // lista con los datos de la db

        //Constructor para crear la conexión
        public ProductLinesService(IOptions<ProductLinesDatabaseSettings> productLinesDatabaseSettings)
        {
            var mongoClient = new MongoClient(
               productLinesDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                productLinesDatabaseSettings.Value.DatabaseName);

            _productLinesCollection = mongoDatabase.GetCollection<ProductLines>(
                productLinesDatabaseSettings.Value.ProductCollectionName);
        }

        public async Task<List<ProductLines>> GetAsync() =>
           await _productLinesCollection.Find(_ => true).ToListAsync();

        public async Task<ProductLines?> GetAsync(string id) =>
            await _productLinesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}
