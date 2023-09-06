using System.Text.Json;

namespace GameAPI.Data {
    public class JsonDataStore : IDataStore {

        List<Game> games;
        string gamesPath = "games.json";

        public JsonDataStore() {
            games = new();
            if (File.Exists(gamesPath)) {
                var json = File.ReadAllText(gamesPath);
                games = JsonSerializer.Deserialize<List<Game>>(json);
            }
        }
        public async Task<Game> AddGame(Game game) {
            if(games.Count == 0) {
                game.Id = 1;
            } else {
                game.Id = games.Max(r => r.Id) + 1;   
            }

            games.Add(game);
            await saveGames();
            return game;
        }

        private async Task saveGames() {
            var json = JsonSerializer.Serialize(games);
            await File.WriteAllTextAsync(gamesPath, json);
        }

        public Task DeleteGame(int id) {
            games.RemoveAt(id);
            return Task.CompletedTask;  
        }

        public async Task<IEnumerable<Game>> GetAllGames() {
            await Task.CompletedTask;
            return games;
        }

        public async Task<Game> GetGame(int id) {
            Game game = games[id];
            return game;
        }

        public async Task<Game> UpdateGame(int id, Game game) {
            games[id] = game;
            await Task.CompletedTask;
            return game;

        }
    }
}
