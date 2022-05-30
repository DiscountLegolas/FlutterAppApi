using Api.Ef.Models;
using Api.RepositoryPattern.Repos.Interface;
using Api.Dtos.Request;
namespace Api.RepositoryPattern.Services.Class
{
    public class TherapistService:Api.RepositoryPattern.Services.Interface.ITherapistService
    {
        private ITherapistRepo _therapistRepo;
        private IPostRepo _postrepo;
        private IMessageRepo _messageRepo;
        public TherapistService(IPostRepo postRepo,ITherapistRepo therapistRepo,IMessageRepo messageRepo)
        {
            _therapistRepo=therapistRepo;
            _messageRepo=messageRepo;
            _postrepo=postRepo;
        }
        public bool AddTherapist(Therapist therapist)
        {
            return _therapistRepo.AddTherapist(therapist);
        }
        public bool UpdateTherapist(int therapistıd,Therapist therapist){return _therapistRepo.UpdateTherapist(therapistıd,therapist);}
        public bool DeleteTherapist(int therapistıd){return _therapistRepo.DeleteTherapist(therapistıd);}
        public bool MessageFromTherapistToUser(int user,int therapist,string body){return _messageRepo.TherapistMessage(body,user,therapist);}
        public List<Therapist> GetTherapists()
        {
            return _therapistRepo.GetTherapists();
        }
        public bool Login(Therapist therapist)
        {
            return _therapistRepo.Login(therapist);
        }
        public bool AddPost(Post post)
        {
            return _postrepo.AddPost(post);
        }
        public bool DeletePost(int postıd)
        {
            return _postrepo.DeletePost(postıd);
        }
        public bool UpdatePost(int postıd,Post post)
        {
            return _postrepo.UpdatePost(postıd,post);
        }
    }
}