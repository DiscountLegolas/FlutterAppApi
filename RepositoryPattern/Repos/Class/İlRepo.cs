using Api.RepositoryPattern.Repos.Interface;
using Api.Ef.Models;
using Api.Ef;
using Microsoft.EntityFrameworkCore;
namespace Api.RepositoryPattern.Repos.Class
{
    public class İlRepo:IİlRepo
    {
        private KekemelikDbContext _kekemelikDbContext;
        public İlRepo(KekemelikDbContext kekemelikDbContext)
        {
            _kekemelikDbContext=kekemelikDbContext;
        }
        public List<İl> GetİlsWithİlçes()
        {
            _kekemelikDbContext.SaveChanges();
            return _kekemelikDbContext.İls.Include(x=>x.İlçeler).ToList();
        }
    }
}