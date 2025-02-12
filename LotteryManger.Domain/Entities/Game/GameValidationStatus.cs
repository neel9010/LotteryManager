namespace LotteryManger.Domain.Entities
{
    /// <summary>
    /// Game Validation Status
    /// </summary>
    public enum GameValidationStatus : byte
    {
        /// <summary>
        /// Active
        /// </summary>
        Active = 1,

        /// <summary>
        /// Disabled
        /// </summary>
        Disabled = 0,
    }
}