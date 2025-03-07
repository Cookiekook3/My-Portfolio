using Microsoft.Azure.Cosmos;
using System.ComponentModel;
using VideoGameApi.Models;
using Container = Microsoft.Azure.Cosmos.Container;

namespace VideoGameApi.Services
{
    public class VideogameRepository : IVideogameRepository
    {
        private readonly Container _container;

        public VideogameRepository(
            string conn,
            string key,
            string databaseName,
            string containerName)
        {
            var cosmosClient = new CosmosClient(conn, key, new CosmosClientOptions() { });
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }
        public async Task<Videogame> CreateVideogameAsync(Videogame videogame)
        {
            var response = await _container.CreateItemAsync(videogame, new PartitionKey(videogame.Genre));
            return response.Resource;
        }

        public async Task<bool> DeleteVideogame(string id, string genre)
        {
            var response = await _container.DeleteItemAsync<Videogame>(id, new PartitionKey(genre));

            if (response.Resource != null)
                return false;

            return false;
        }

        public async Task<Videogame> GetVideogameAsync(string id, string genre)
        {
            try
            {
                var response = await _container.ReadItemAsync<Videogame>(id, new PartitionKey(genre));
                return response;
            }
            catch (Exception e)
            {
                return null;
            }   
        }

        public async Task<IEnumerable<Videogame>> GetVideogamesAsync()
        {
            var query = _container
                .GetItemQueryIterator<Videogame>(new QueryDefinition("SELECT * FROM c"));

            var results = new List<Videogame>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<Videogame> UpdateVideogameAsync(string id, Videogame videogame)
        {
            var response = await _container.UpsertItemAsync(videogame, new PartitionKey(videogame.Genre));
            return response.Resource;
        }
    }
}
