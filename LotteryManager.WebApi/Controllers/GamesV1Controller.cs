﻿using LotteryManager.Business.Services;
using LotteryManager.WebApi.Models;
using LotteryManger.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace LotteryManager.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Tags("Lottery Instant Games")]
    public class GamesV1Controller(IGameService gameService) : ControllerBase
    {
        private readonly IGameService _gameService = gameService;

        [HttpGet("games/{state}")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Games retrieved successfully", typeof(IEnumerable<GameV1Response>))]
        public async Task<IActionResult> GetAllGamesByState(string state)
        {
            var game = await _gameService.GetAllGamesByStateAsync(state);
            var response = game?.Select(x => new GameV1Response
            {
                GameId = x.GameId,
                GameName = x.GameName,
                TotalTicketsInPack = x.TotalTicketsInPack,
                TicketPrice = x.TicketPrice,
                ValidationStatus = x.ValidationStatus.GetDisplayName(),
            });

            return Ok(response);
        }
    }
}