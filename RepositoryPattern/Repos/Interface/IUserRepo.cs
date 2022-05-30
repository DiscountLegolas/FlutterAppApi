using Api.Ef.Models;
namespace Api.RepositoryPattern.Repos.Interface
{
    public interface IUserRepo
    {
        public bool UpdateUser(int userid,User user);
        public bool DeleteUser(int userid);
        public bool AddUser(User user);
        public bool Login(User user);
        public List<User> GetUsers();
    }
}