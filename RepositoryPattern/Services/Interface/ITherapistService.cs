using Api.Ef.Models;
using Api.Dtos.Request;
namespace Api.RepositoryPattern.Services.Interface
{
    public interface ITherapistService
    {
        public bool AddTherapist(Therapist therapist);
        public bool UpdateTherapist(int therapistıd,Therapist therapist);
        public bool DeleteTherapist(int therapistıd);
        public bool MessageFromTherapistToUser(int user,int therapist,string body);
        public List<Therapist> GetTherapists();
        public bool Login(Therapist therapist);
        public bool AddPost(Post post);
        public bool DeletePost(int postıd);
        public bool UpdatePost(int postıd,Post post);

    }
}