using Microsoft.AspNetCore.Mvc;
using GameAPI.Data;


namespace GameAPI.Controllers {



    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase {
        private readonly ILogger<GameController> _logger;
        private readonly IDataStore dataStore;

        public GameController(ILogger<GameController> logger, IDataStore dataStore) {
            _logger = logger;
            this.dataStore = dataStore;
        }


        [HttpGet]
        public async Task<IEnumerable<Game>> Get() {
            return await dataStore.GetAllGames();
        }

        [HttpGet("get/{id}")]
        public async Task<Game> Get(int id) {
            return await dataStore.GetGame(id);
        }
        [HttpPost]
        public async Task<Game> Post([FromBody] Game game) {
            var newGame = await dataStore.AddGame(game);
            return newGame;
        }
        [HttpPost("update/{id}")]
        public async Task<Game> Update(int id, [FromBody] Game game) {
            var updateGame = await dataStore.UpdateGame(id, game);
            return updateGame;
        }

        [HttpDelete]
        public async Task Delete(int id) {
            await dataStore.DeleteGame(id);
        }

    }
}