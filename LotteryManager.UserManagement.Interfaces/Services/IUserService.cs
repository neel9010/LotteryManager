namespace LotteryManager.UserManagement.Interfaces
{
    public interface IUserService
    {
        IAuthenticateResponse Authenticate(IAuthenticateRequest model);

        IEnumerable<IUser> GetAll();

        IUser GetById(int id);

        void Register(IRegisterRequest model);

        void Update(int id, IUpdateRequest model);

        void Delete(int id);
    }
}