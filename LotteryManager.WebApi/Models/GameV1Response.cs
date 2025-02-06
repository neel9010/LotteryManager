namespace LotteryManager.WebApi.Models
{
    public record GameV1Response
    {
        public int GameId { get; init; }
        public string GameName { get; init; }
        public string ValidationStatus { get; init; }
        public decimal TicketPrice { get; init; }
        public int TotalTicketsInPack { get; init; }
    }
}