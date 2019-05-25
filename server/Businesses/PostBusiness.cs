using System;
using System.Linq;
using System.Threading.Tasks;
using server.DataAccesses;
using server.Middleware.Error;
using server.Models;

namespace server.Businesses
{
    public static class PostBusiness
    {
        public static IQueryable<Post> List => PostDataAccess.List;

        public static Post Get(int id)
        {
            var post = PostDataAccess.Get(id);
            if (post == null) throw new Error404NotFound<Post>(id);

            return post;
        }

        public static async Task<Post> Add(Post post)
        {
            if (post.Title.Length < 5)
                throw new Error400BadRequest<Post>(
                    "Tiêu đề bài viết phải có nhiều hơn 5 ký tự"
                );

            if (post.Content.Length < 10)
                throw new Error400BadRequest<Post>(
                    "Nội dung bài viết phải có nhiều hơn 10 ký tự"
                );

            return await PostDataAccess.Add(post);
        }
    }
}
