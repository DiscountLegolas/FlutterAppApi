using Api.Ef.Models;
namespace Api.RepositoryPattern.Services.Interface
{
    public interface IUserService
    {
        public bool AddUser(User user);
        public bool UpdateUser(int userıd,User user);
        public bool DeleteUser(int user);
        public bool SendMessageToUser(int user1,int user2,string body);
        public bool SendMessageToTherapist(int user,int therapist,string body);
        public List<User> GetUsers();
        public bool Login(User user);
    }
}