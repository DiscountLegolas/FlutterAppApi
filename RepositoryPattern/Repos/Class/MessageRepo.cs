using Api.RepositoryPattern.Repos.Interface;
using Api.Ef.Models;
using Api.Ef;
namespace Api.RepositoryPattern.Repos.Class
{
    public class MessageRepo:IMessageRepo
    {
        private KekemelikDbContext _kekemelikDbContext;
        public MessageRepo(KekemelikDbContext kekemelikDbContext)
        {
            _kekemelikDbContext=kekemelikDbContext;
        }
        public bool UserMessage(string body,int user1,int user2)
        {
            try
            {
                UserMessage um=new UserMessage(){Body=body,DateTime=DateTime.Now,User1Id=user1,User2Id=user2};
                _kekemelikDbContext.UserMessages.Add(um);
                _kekemelikDbContext.SaveChanges();
                _kekemelikDbContext.Dispose();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
         public bool TherapistMessage(string body,int user,int therapist)
         {
            try
            {
                TherapistMessage tm=new TherapistMessage(){Body=body,DateTime=DateTime.Now,UserId=user,TherapistId=therapist};
                _kekemelikDbContext.TherapistMessages.Add(tm);
                _kekemelikDbContext.SaveChanges();
                _kekemelikDbContext.Dispose();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
         }
    }
}