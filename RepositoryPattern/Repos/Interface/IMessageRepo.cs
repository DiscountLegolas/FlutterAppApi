namespace Api.RepositoryPattern.Repos.Interface
{
    public interface IMessageRepo
    {
         public bool UserMessage(string body,int user1,int user2);
         public bool TherapistMessage(string body,int user,int therapist);
    }
}