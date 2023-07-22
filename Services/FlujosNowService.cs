using SupportPageApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SupportPageApi.Services
{
    public class FlujosNowService
    {
        private readonly IMongoCollection<FlujosNow> _flujosnowCollection; // lista con los datos de la db

        //Constructor para crear la conexión
        public FlujosNowService(
           IOptions<FlujosNowDatabaseSettings> flujosnowDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                flujosnowDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                flujosnowDatabaseSettings.Value.DatabaseName);

            _flujosnowCollection = mongoDatabase.GetCollection<FlujosNow>(
                flujosnowDatabaseSettings.Value.SupportCollectionName);
        }

        public async Task<List<FlujosNow>> GetAsync() =>
            await _flujosnowCollection.Find(_ => true).ToListAsync();

        public async Task<FlujosNow?> GetAsync(string id) =>
            await _flujosnowCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        
        public async Task CreateAsync(FlujosNow newResourse) =>
            await _flujosnowCollection.InsertOneAsync(newResourse);

        public async Task UpdateAsync(string id, FlujosNow updatedResource) =>
            await _flujosnowCollection.ReplaceOneAsync(x => x.Id == id, updatedResource);

        public async Task RemoveAsync(string id) =>
            await _flujosnowCollection.DeleteOneAsync(x => x.Id == id);

    }
}
