using SharedModels;
using UsersService.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace UsersService.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private static List<User> _users = new List<User>();
        private int nextUserId = 1;
        public UsersRepository() { }

        public void AddUser(User user)
        {
            if (_users.Any(x => x.Name == user.Name))
            {
                throw new InvalidOperationException("Користувач з таким логіном вже існує.");
            }

            user.Id = nextUserId++;
            _users.Add(user);
        }

        public void DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new InvalidOperationException($"Користувач з ID {id} не знайдений.");
            }

            _users.Remove(user);
        }

        public User GetUserById(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new InvalidOperationException($"Користувач з ID {id} не знайдений.");
            }

            return user;
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public void UpdateUser(int id, User newUser)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new InvalidOperationException($"Користувач з ID {id} не знайдений.");
            }
            user.Name = newUser.Name;
            user.Email = newUser.Email;
        }
    }
}
