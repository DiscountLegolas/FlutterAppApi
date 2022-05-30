using Api.Ef.Models;
namespace Api.RepositoryPattern.Repos.Interface
{
    public interface ITherapistRepo
    {
        public bool UpdateTherapist(int tıd,Therapist therapist);
        public bool DeleteTherapist(int tıd);
        public bool AddTherapist(Therapist therapist);
        public bool Login(Therapist therapist);
        public List<Therapist> GetTherapists();
    }
}