using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Service.IRepository;
using Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Service.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _context;
        public UserRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            //var users = Enumerable.Range(1, 5).Select(x => new User
            //{
            //    Id = x,
            //    FirstName = $"First Name {x}",
            //    LastName = $"Lasst Name {x}",
            //    Email = $"email.com {x}",
            //    Password = $"Password {x}",
            //    CDate = DateTime.Now
            //});
            //await Task.Delay(2000);
            var users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<User> GetUser(string userid)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.UserId==userid);
            return user;
        }
        public async Task<User> AddUser(User user)
        {
            var nuser = await _context.Users.AddAsync(user);
            _context.SaveChanges();
            return user;
        }
        public async Task<User> UpdateUser(User user)
        {
            // _context.Entry(user).State = EntityState.Modified;
            //_context.Users.FirstOrDefault(x=>x.UserId==user.UserId).= EntityState.Modified;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
