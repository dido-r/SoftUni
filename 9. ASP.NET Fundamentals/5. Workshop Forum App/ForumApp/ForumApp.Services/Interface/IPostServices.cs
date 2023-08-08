using ForumApp.Services.Models;

namespace ForumApp.Services.Interface
{
    public interface IPostServices
    {
        Task<List<PostViewModel>> GetAllPosts();

        Task CreatePost(PostViewModel model);

        Task<PostViewModel> GetCurrentPost(int id);

        Task EditCurrentPost(int id, PostViewModel model);

        Task DeletePost(int id);
    }
}
