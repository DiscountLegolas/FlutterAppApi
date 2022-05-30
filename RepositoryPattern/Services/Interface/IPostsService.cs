using Api.Ef.Models;
namespace Api.RepositoryPattern.Services.Interface
{
    public interface IPostsService
    {
        public List<Post> GetAllPosts();
        public List<Post> GetPostsByTherapist(int therapistıd);
        public List<Post> GetPostsByMinDate(DateTime date);
        public List<Post> GetPostsByTopics(List<string> topics);
    }
}