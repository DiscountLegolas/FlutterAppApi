using Api.RepositoryPattern.Repos.Interface;
using Api.Ef.Models;
using Api.Ef;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
namespace Api.RepositoryPattern.Repos.Class
{
    public class TherapistRepo:ITherapistRepo
    {
        private KekemelikDbContext _kekemelikDbContext;
        public TherapistRepo(KekemelikDbContext kekemelikDbContext)
        {
            _kekemelikDbContext=kekemelikDbContext;
        }
        public bool UpdateTherapist(int tıd,Therapist therapist)
        {
            try
            {
                var oldaccount=_kekemelikDbContext.Therapists.Single(x=>x.TherapistId==tıd);
                foreach (var item in oldaccount.GetType().GetProperties())
                {
                    var property=therapist.GetType().GetProperty(item.Name);
                    if (property!=null&&property.GetValue(therapist)!=null&&item.GetValue(oldaccount)!=property.GetValue(therapist))
                    {
                        if (property.GetValue(therapist)!=property.GetConstantValue())
                        {
                            item.SetValue(oldaccount,property.GetValue(therapist));
                        }
                    }
                }
                string pass=Hash(therapist.Password);
                therapist.Password=pass;
                oldaccount.TherapistId=tıd;
                _kekemelikDbContext.SaveChanges();
                _kekemelikDbContext.Dispose();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public bool DeleteTherapist(int tıd)
        {
            try
            {
                _kekemelikDbContext.Posts.RemoveRange(_kekemelikDbContext.Posts.Where(x=>x.TherapistId==tıd));
                _kekemelikDbContext.TherapistMessages.RemoveRange(_kekemelikDbContext.TherapistMessages.Where(x=>x.TherapistId==tıd));
                _kekemelikDbContext.Therapists.Remove(_kekemelikDbContext.Therapists.Single(x=>x.TherapistId==tıd));
                _kekemelikDbContext.SaveChanges();
                _kekemelikDbContext.Dispose();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public bool AddTherapist(Therapist therapist)
        {
            string pass=Hash(therapist.Password);
            therapist.Password=pass;
            if (_kekemelikDbContext.Therapists.Any(x=>(x.Name==therapist.Name&&x.Surname==therapist.Surname)||x.EMail==therapist.EMail||x.Telefon==therapist.Telefon))
            {
                _kekemelikDbContext.Dispose();
                return false;
            }
            try
            {
                _kekemelikDbContext.Therapists.Add(therapist);
                _kekemelikDbContext.SaveChanges();
                _kekemelikDbContext.Dispose();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public List<Therapist> GetTherapists()
        {
            var a=_kekemelikDbContext.Therapists.Include(x=>x.Messages).Include(b=>b.Posts).Include(x=>x.İlçe).ThenInclude(a=>a.İl).ToList();
            _kekemelikDbContext.Dispose();
            return a;
        }
        public bool Login(Therapist therapist)
        {
            try
            {
                string pass=Hash(therapist.Password);
                therapist.Password=pass;
                if (_kekemelikDbContext.Therapists.Any(x=>(x.Password==therapist.Password&&x.EMail==therapist.EMail)))
                {
                    return true;
                }
                else
                {
                    _kekemelikDbContext.Dispose();
                    return false;
                }
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        private string Hash(string pass)
        {
            using (var al=SHA256.Create())
            {
                var hash=al.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
                return BitConverter.ToString(hash).Replace("-",string.Empty);
            }
        }
    }
}