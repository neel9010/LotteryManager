using LotteryManger.Domain.Entities;

namespace LotteryManager.WebApi.Models
{
    /// <summary>
    /// Game Response
    /// </summary>
    public record GameV1Response
    {
        /// <summary>
        /// Game Id
        /// </summary>
        public int GameId { get; init; }

        /// <summary>
        /// Game Name
        /// </summary>
        public required string GameName { get; init; }

        /// <summary>
        /// Game State
        /// </summary>
        public required string State { get; init; }

        /// <summary>
        /// Game Validation Status <see cref="GameValidationStatus"/>
        /// </summary>
        public required string ValidationStatus { get; init; }

        /// <summary>
        /// Ticket Price
        /// </summary>
        public decimal TicketPrice { get; init; }

        /// <summary>
        /// Total Numbers of Tickets in a Pack
        /// </summary>
        public int TotalTicketsInPack { get; init; }
    }
}