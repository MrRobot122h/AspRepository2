using SharedModels;

namespace UsersService.Interfaces
{
    public interface IUsersRepository
    {
        public void AddUser(User user);
        public void UpdateUser(int id, User user);
        public void DeleteUser(int id);
        public User GetUserById(int id);
        public List<User> GetUsers();

    }
}
