using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.DataModel;

namespace BlogApi
{
    public interface IUserRepository
{
    User FindUser(string username, string password);
}

public class UserRepository : IUserRepository
{
    private Contexto _context;

    public UserRepository(Contexto context)
    {
        _context = context;
    }

    public User FindUser(string username, string password)
    {
        return _context.Users.SingleOrDefault(u => u.DisplayName == username && u.Password == password);
    }
}
}