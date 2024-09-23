using SharedModels;

namespace UsersService.Interfaces
{
    public interface IUserService
    {
        public void Add(User user);
        public void Update(int id, User user);
        public void Delete(int id);
        public User GetUser(int id);
        public List<User> GetUsers();



    }
}
