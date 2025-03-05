using LotteryManager.Business.Services;
using LotteryManager.WebApi.Models;
using LotteryManger.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace LotteryManager.WebApi.Controllers.Games
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiController]
    [Tags("Lottery Instant Games")]
    [Route("api/v1")]
    public class GamesV1Controller(IGameService gameService) : ControllerBase
    {
        private readonly IGameService _gameService = gameService;

        [HttpGet("games/{state}")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Games retrieved successfully", typeof(IEnumerable<GameV1Response>))]
        public async Task<IActionResult> GetAllGamesByState(string state)
        {
            IEnumerable<Game>? game = await _gameService.GetAllGamesByStateAsync(state);
            IEnumerable<GameV1Response>? response = game?.Select(x => new GameV1Response
            {
                GameId = x.GameId,
                GameName = x.GameName,
                TotalTicketsInPack = x.TotalTicketsInPack,
                TicketPrice = x.TicketPrice,
                State = state.ToUpper(),
                ValidationStatus = x.ValidationStatus.GetDisplayName(),
            });

            return Ok(response);
        }
    }
}