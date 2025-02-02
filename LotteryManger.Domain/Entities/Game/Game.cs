namespace LotteryManger.Domain.Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string State { get; set; }
        public GameValidationStatus ValidationStatus { get; set; }
        public decimal TicketPrice { get; set; }
        public int TotalTicketsInPack { get; set; }
    }
}