using Api.RepositoryPattern.Repos.Interface;
using Api.Ef.Models;
using Api.Ef;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
namespace Api.RepositoryPattern.Repos.Class
{
    
    public class UserRepo:IUserRepo
    {
        private KekemelikDbContext _kekemelikDbContext;
        public UserRepo(KekemelikDbContext kekemelikDbContext)
        {
            _kekemelikDbContext=kekemelikDbContext;
        }
        public bool AddUser(User user)
        {
            string pass=Hash(user.Password);
            user.Password=pass;
            if (_kekemelikDbContext.Users.Any(x=>x.UserName==user.UserName||x.EMail==user.EMail||(x.Telefon!=null&&x.Telefon==user.Telefon)))
            {
                return false;
            }
            try
            {
                _kekemelikDbContext.Users.Add(user);
                _kekemelikDbContext.SaveChanges();
                return true;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                _kekemelikDbContext.Dispose();
                return false;
            }

        }
        public bool Login(User user)
        {
            string pass=Hash(user.Password);
            user.Password=pass;
            if (_kekemelikDbContext.Users.Any(x=>(x.Password==user.Password&&x.EMail==user.EMail)||(x.UserName==user.UserName&&x.Password==user.Password)))
            {
                return true;
            }
            else
            {
                _kekemelikDbContext.Dispose();
                return false;
            }
        }
        public bool UpdateUser(int userid,User user)
        {
            try
            {
                var oldaccount=_kekemelikDbContext.Users.Single(x=>x.UserId==userid);
                foreach (var item in oldaccount.GetType().GetProperties())
                {
                    var property=user.GetType().GetProperty(item.Name);
                    if (property!=null&&property.GetValue(user)!=null&&item.GetValue(oldaccount)!=property.GetValue(user))
                    {
                        item.SetValue(oldaccount,property.GetValue(user));
                    }
                }
                oldaccount.UserId=userid;
                string pass=Hash(user.Password);
                user.Password=pass;
                _kekemelikDbContext.SaveChanges();
                _kekemelikDbContext.Dispose();
                return true;
            }
            catch (System.Exception)
            {
                _kekemelikDbContext.Dispose();
                return false;
            }
        }
        public bool DeleteUser(int userid)
        {
            try
            {
                _kekemelikDbContext.UserMessages.RemoveRange(_kekemelikDbContext.UserMessages.Where(x=>x.User1Id==userid||x.User2Id==userid));
                _kekemelikDbContext.Users.Remove(_kekemelikDbContext.Users.Single(x=>x.UserId==userid));
                _kekemelikDbContext.SaveChanges();
                _kekemelikDbContext.Dispose();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public List<User> GetUsers()
        {
            var usrs=_kekemelikDbContext.Users.Include(x=>x.TherapistMessages).Include(x=>x.User1Messages).Include(x=>x.User2Messages).ToList();
            _kekemelikDbContext.Dispose();
            return usrs;
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