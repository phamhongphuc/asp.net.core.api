using System;
using System.Linq;
using System.Threading.Tasks;
using server.DataAccesses;
using server.Models;

namespace server.Businesses
{
    public static class PostBusiness
    {
        public static IQueryable<Post> List => PostDataAccess.List;

        public static Post Get(int id)
        {
            var post = PostDataAccess.Get(id);
            if (post == null) throw new Exception("Item Not Found");

            return post;
        }

        public static async Task<Post> Add(Post post)
        {
            if (post.Title.Length < 5)
                throw new Exception("Post title must be more than 5 characters");

            if (post.Content.Length < 10)
                throw new Exception("Post content must be more than 10 characters");

            return await PostDataAccess.Add(post);
        }
    }
}