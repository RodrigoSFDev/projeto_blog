using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.DataModel.Interfaces
{
    public interface IUserService
    {
        Task<User> Register(User user, string password);
        Task<string> Authenticate(string email, string password);
        Task<User> Update(int id, User user);
        Task Delete(int id);
    }
}