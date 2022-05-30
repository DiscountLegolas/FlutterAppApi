using Api.Ef.Models;
using Api.RepositoryPattern.Repos.Interface;
namespace Api.RepositoryPattern.Services.Class
{
    public class PostsService:Api.RepositoryPattern.Services.Interface.IPostsService
    {
        private IPostRepo _postrepo;
        public PostsService(IPostRepo postRepo)
        {
            _postrepo=postRepo;
        }
        public List<Post> GetAllPosts()
        {
            return _postrepo.GetAllPosts();
        }
        public List<Post> GetPostsByTherapist(int therapistıd)
        {
            return _postrepo.GetAllPosts().Where(x=>x.TherapistId==therapistıd).ToList();
        }
        public List<Post> GetPostsByMinDate(DateTime date)
        {
            return _postrepo.GetAllPosts().Where(x=>x.DateTime.Day>=date.Day&&x.DateTime.Year>=date.Year).ToList();
        }
        public List<Post> GetPostsByTopics(List<string> topics)
        {
            return _postrepo.GetAllPosts().Where(x=>topics.Any(a=>x.Topic==a)).ToList();
        }
    }
}