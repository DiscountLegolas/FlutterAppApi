using Api.Ef.Models;
using Api.RepositoryPattern.Repos.Interface;
namespace Api.RepositoryPattern.Services.Class
{
    public class UserService:Api.RepositoryPattern.Services.Interface.IUserService
    {
        private IUserRepo _userRepo;
        private IMessageRepo _messageRepo;
        public UserService(IUserRepo userRepo,IMessageRepo messageRepo)
        {
            _userRepo=userRepo;
            _messageRepo=messageRepo;
        }
        public bool AddUser(User user)
        {
            return _userRepo.AddUser(user);
        }
        public bool UpdateUser(int userıd,User user)
        {
            return _userRepo.UpdateUser(userıd,user);
        }
        public bool DeleteUser(int user)
        {
            return _userRepo.DeleteUser(user);
        }
        public bool SendMessageToUser(int user1,int user2,string body)
        {
            return _messageRepo.UserMessage(body,user1,user2);
        }
        public bool SendMessageToTherapist(int user,int therapist,string body)
        {
            return _messageRepo.TherapistMessage(body,user,therapist);
        }
        public List<User> GetUsers()
        {
            return _userRepo.GetUsers();
        }
        public bool Login(User user)
        {
            return _userRepo.Login(user);
        }
    }
}