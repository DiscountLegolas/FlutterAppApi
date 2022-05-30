using Api.RepositoryPattern.Repos.Interface;
using Api.Ef.Models;
using Api.Ef;
using Microsoft.EntityFrameworkCore;
namespace Api.RepositoryPattern.Repos.Class
{
    public class PostRepo:IPostRepo
    {
        private KekemelikDbContext _kekemelikDbContext;
        public PostRepo(KekemelikDbContext kekemelikDbContext)
        {
            _kekemelikDbContext=kekemelikDbContext;
        }
        public bool AddPost(Post post)
        {
            try
            {
                post.DateTime=DateTime.Now;
                post.Approved=true;
                _kekemelikDbContext.Posts.Add(post);
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
        public bool UpdatePost(int postıd,Post post)
        {
            try
            {
                var oldpost=_kekemelikDbContext.Posts.Single(x=>x.PostId==postıd);
                oldpost.Content=post.Content;
                oldpost.Topic=post.Topic;
                oldpost.Title=post.Title;
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
        public bool DeletePost(int postıd)
        {

            try
            {
                _kekemelikDbContext.Posts.Remove(_kekemelikDbContext.Posts.Single(x=>x.PostId==postıd));
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
        public List<Post> GetAllPosts()
        {
            try
            {
                List<Post> posts=_kekemelikDbContext.Posts.Include(x=>x.Publisher).ThenInclude(x=>x.İlçe).ThenInclude(a=>a.İl).Where(x=>x.Approved==true).ToList();
                _kekemelikDbContext.Dispose();
                return posts;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}