using System;
using System.Linq;
using System.Threading.Tasks;
using blog.server.DataAccesses.Base;
using blog.server.Models;

namespace blog.server.DataAccesses
{
    public class PostDataAccess : ModelHasIdDataAccess<Post>
    {
        public static async Task<Post> Add(Post post)
        {
            await Database.WriteAsync(realm =>
            {
                post.Id = NextId;
                post.Created = DateTimeOffset.Now;
                post.Modified = null;
                post = realm.Add(post);
            });
            return post;
        }

        public static async Task<Post> Update(Post postInDatabase, Post post)
        {
            await Database.WriteAsync(realm =>
            {
                postInDatabase.Title = post.Title;
                postInDatabase.Content = post.Content;
                postInDatabase.Cover = post.Cover;
                postInDatabase.Modified = DateTimeOffset.Now;
            });
            return postInDatabase;
        }

        public static async Task Delete(Post post)
        {
            await Database.WriteAsync(realm => realm.Remove(post));
        }
    }
}
