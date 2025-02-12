namespace LotteryManger.Domain.Entities
{
    /// <summary>
    /// Instant Scratcher Game
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Game Id
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// Game Name
        /// </summary>
        public required string GameName { get; set; }

        /// <summary>
        /// Game State
        /// </summary>
        public required string State { get; set; }

        /// <summary>
        /// Game Validation Status <see cref="GameValidationStatus"/>
        /// </summary>
        public GameValidationStatus ValidationStatus { get; set; }

        /// <summary>
        /// Ticket Price
        /// </summary>
        public decimal TicketPrice { get; set; }

        /// <summary>
        /// Total Numbers of Tickets in a Pack
        /// </summary>
        public int TotalTicketsInPack { get; set; }
    }
}