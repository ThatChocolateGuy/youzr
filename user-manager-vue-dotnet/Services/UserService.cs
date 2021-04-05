using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user_manager_vue_dotnet.Entities;
using user_manager_vue_dotnet.Helpers;

namespace user_manager_vue_dotnet.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        Task<IEnumerable<User>> GetAllAdmin();
        Task<int> SeedUsers();
        Task<bool> CheckForEmptyDb();
        Task<User> GetUser(int id);
        Task UpdateUserAsync(User user);
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(int userId);
        bool UserExists(int id);
    }

    public class UserService : IUserService
    {
        public UserContext _context;

        // users will be seeded in db
        private readonly IEnumerable<User> _seedUsers = new List<User>
        {
            new User { UserId = 1, Name = "User 1", Email = "user1@user.com", Password = "user1pw" },
            new User { UserId = 2, Name = "User 2", Email = "user2@user.com", Password = "user2pw" },
            new User { UserId = 3, Name = "User 3", Email = "user3@user.com", Password = "user3pw" }
        };

        public UserService(UserContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _context.Users.SingleOrDefault(
                x => x.Email == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            return user.WithoutPassword();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => _context.Users.WithoutPasswords());
        }

        public async Task<IEnumerable<User>> GetAllAdmin()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await Task.Run(
                () => _context.Users.SingleOrDefault(x => x.UserId == id).WithoutPassword());
        }

        public async Task UpdateUserAsync(User user)
        {
            var _user = await _context.Users.SingleOrDefaultAsync(u => u.UserId == user.UserId);

            var changedUser = new User()
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password.Length > 1 ? user.Password : _user.Password
            };

            try
            {
                var entityEntry = _context.Attach(changedUser);
                var entity = entityEntry.Entity;
                //var entityState = entityEntry.State = EntityState.Modified;
                var entityStateName = entityEntry.Property(x => x.Name);
                var entityStateEmail = entityEntry.Property(x => x.Email);
                var entityStatePw = entityEntry.Property(x => x.Password);

                entityStateName.IsModified = entityStateEmail.IsModified = entityStatePw.IsModified = true;
                var entitiesUpdates = _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await Task.Run(() => _context.Users.SingleOrDefault(
                x => x.UserId == userId));

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public async Task<int> SeedUsers()
        {
            int x;
            try
            {
                await _context.Users.AddRangeAsync(_seedUsers);
                x = await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return x;
        }

        public async Task<bool> CheckForEmptyDb()
        {
            var user = await _context.Users.FirstOrDefaultAsync();
            if (user != null)
                return true;
            
            return false;
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
