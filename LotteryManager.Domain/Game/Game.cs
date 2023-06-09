namespace LotteryManager.Domain.Game
{
    /// <summary>
    /// Lottery Game
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Game ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Game Name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Game Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Game State
        /// </summary>
        public string State { get; set; } = string.Empty;
    }
}