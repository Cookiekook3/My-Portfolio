using VideoGameApi.Models;

namespace VideoGameApi.Services
{
    public interface IVideogameRepository
    {
        Task<IEnumerable<Videogame>> GetVideogamesAsync();
        Task<Videogame> GetVideogameAsync(string id, string genre);
        Task<Videogame> CreateVideogameAsync(Videogame videogame);
        Task<Videogame> UpdateVideogameAsync(string id, Videogame videogame);
        Task<bool> DeleteVideogame(string id, string genre);
    }
}
