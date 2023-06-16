using LotteryManager.Domain.Game;
using LotteryManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LotteryManager.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<Game>> GetAllGames(string state)
        {
            IEnumerable<Game> games = await _gameService.GetAllGames(state);
            return Ok(games);
        }
    }
}