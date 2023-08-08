using ForumApp.Database.Database;
using ForumApp.Database.Models;
using ForumApp.Services.Interface;
using ForumApp.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Services.Services
{
    public class PostServices : IPostServices
    {
        private ForumAppDbContext context;
        public PostServices(ForumAppDbContext data)
        {
            context = data;
        }

        public async Task CreatePost(PostViewModel model)
        {
            var post = new Post
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content,
            };
            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
        }

        public async Task DeletePost(int id)
        {
            var currentPost = await context.Posts.FindAsync(id);
            context.Posts.Remove(currentPost);
            await context.SaveChangesAsync();
        }

        public async Task EditCurrentPost(int id, PostViewModel model)
        {
            var currentPost = await context.Posts.FindAsync(id);
            currentPost.Id = model.Id;
            currentPost.Title = model.Title;
            currentPost.Content = model.Content;

            await context.SaveChangesAsync();
        }

        public async Task<List<PostViewModel>> GetAllPosts()
        {
            return await context.Posts.Select(x => new PostViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content
            }).ToListAsync();
        }

        public async Task<PostViewModel> GetCurrentPost(int id)
        {
            var currentPost = await context.Posts.FindAsync(id);

            var post = new PostViewModel
            {
                Title = currentPost.Title,
                Content = currentPost.Content
            };

            return post;
        }
    }
}
