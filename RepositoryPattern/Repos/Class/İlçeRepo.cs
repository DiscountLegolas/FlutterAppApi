using Api.RepositoryPattern.Repos.Interface;
using Api.Ef.Models;
using Microsoft.EntityFrameworkCore;
using Api.Ef;
namespace Api.RepositoryPattern.Repos.Class
{
    public class İlçeRepo:IİlçeRepo
    {
        private KekemelikDbContext _kekemelikDbContext;
        public İlçeRepo(KekemelikDbContext kekemelikDbContext)
        {
            _kekemelikDbContext=kekemelikDbContext;
        }
        public İlçe GetİlçeWithItsİl(int ilçeıd)
        {
            return _kekemelikDbContext.İlçes.Include(a=>a.İl).Single(x=>x.İlçeId==ilçeıd);
        }
    }
}