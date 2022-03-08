using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.IRepository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUser(string userid);
        public Task<User> AddUser(User user);
        public Task<User> UpdateUser(User user);

    }
}
