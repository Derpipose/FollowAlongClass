namespace GameAPI.Data {
    public class InMemoryDataStore : IDataStore
    {
        private List<Game> games = new List<Game>();


		public async Task<IEnumerable<Game>> GetAllGames()
        {
            await Task.CompletedTask;
            return games;
        }
		public Task<Game> GetGame(int id)
        {
            return Task.FromResult(games.FirstOrDefault(g=>g.Id == id));
        }
		public Task<Game> AddGame(Game game)
        {
			if (game.Id == 0)
			{
				game.Id = games.Count() + 1;
			}
			games.Add(game);
			return Task.FromResult(game);
		}
		public async Task<Game> UpdateGame(int id, Game game)
        {
            await DeleteGame(id);
            return await AddGame(game);
        }
		public Task DeleteGame(int id)
        {
            games.RemoveAll(g=> g.Id == id);
            return Task.CompletedTask;
        }
	}
}
