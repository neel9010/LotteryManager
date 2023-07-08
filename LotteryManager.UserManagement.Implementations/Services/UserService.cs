using LotteryManager.DataAccess.Interfaces;
using LotteryManager.UserManagement.Interfaces;

namespace LotteryManager.UserManagement.Implementations
{
    public class UserService : IUserService
    {
        private readonly IJwtUtils _jwtUtils;
        private readonly IDBAccess _dBAccess;

        public UserService(IJwtUtils jwtUtils, IDBAccess dBAccess)
        {
            _jwtUtils = jwtUtils;
            _dBAccess = dBAccess;
        }

        public IAuthenticateResponse Authenticate(IAuthenticateRequest model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public IUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Register(IRegisterRequest model)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, IUpdateRequest model)
        {
            throw new NotImplementedException();
        }
    }
}