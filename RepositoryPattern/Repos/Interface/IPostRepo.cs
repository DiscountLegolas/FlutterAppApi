using Api.Ef.Models;
namespace Api.RepositoryPattern.Repos.Interface
{
    public interface IPostRepo
    {
        public bool AddPost(Post post);
        public bool UpdatePost(int postıd,Post post);
        public bool DeletePost(int postıd);
        public List<Post> GetAllPosts();
    }
}