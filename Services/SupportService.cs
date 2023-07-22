using SupportPageApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SupportPageApi.Services
{
    public class SupportService
    {
        private readonly IMongoCollection<ResourcesPage> _supportCollection;

        public SupportService(
            IOptions<SupportDatabaseSettings> supportDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                supportDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                supportDatabaseSettings.Value.DatabaseName);

            _supportCollection = mongoDatabase.GetCollection<ResourcesPage>(
                supportDatabaseSettings.Value.SupportCollectionName);
        }

        public async Task<List<ResourcesPage>> GetAsync() =>
            await _supportCollection.Find(_ => true).ToListAsync();

        //public async Task<ResourcesPage?> GetAsync(string id) =>
          //  await _supportCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<ResourcesPage?> GetAsync(string id) =>
          await _supportCollection.Find(x => x.id_section == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ResourcesPage newResourse) =>
            await _supportCollection.InsertOneAsync(newResourse);

        public async Task UpdateAsync(string id, ResourcesPage updatedResource) =>
            await _supportCollection.ReplaceOneAsync(x => x.Id == id, updatedResource);

        public async Task RemoveAsync(string id) =>
            await _supportCollection.DeleteOneAsync(x => x.Id == id);
    }
}
