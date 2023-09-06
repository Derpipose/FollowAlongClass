using System.Xml.Linq;

namespace GameAPI.Data {
    public interface IDataStore {
        Task <IEnumerable<Game>> GetAllGames();
        Task<Game> GetGame(int id);
        Task<Game> AddGame(Game game);
        Task<Game> UpdateGame(int id, Game game);
        Task DeleteGame(int id);
    }
}
