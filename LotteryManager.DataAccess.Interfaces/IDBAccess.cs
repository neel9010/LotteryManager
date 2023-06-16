using System.Data;

namespace LotteryManager.DataAccess.Interfaces
{
    public interface IDBAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");

        Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default");

        void CreateConnection(string connectionId);
    }
}