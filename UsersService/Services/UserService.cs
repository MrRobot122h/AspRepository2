using SharedModels;
using UsersService.Interfaces;

namespace UsersService.Services
{
    public class UserService : IUserService
    {
        IUsersRepository _usersRepository;
        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public void Add(User user)
        {
            _usersRepository.AddUser(user);
        }

        public void Delete(int id)
        {
            _usersRepository.DeleteUser(id);
        }

        public User GetUser(int id)
        {
            return _usersRepository.GetUserById(id);
        }

        public List<User> GetUsers()
        {
            return _usersRepository.GetUsers();
        }

        public void Update(int id, User user)
        {
            _usersRepository.UpdateUser(id, user);
        }
    }
}
