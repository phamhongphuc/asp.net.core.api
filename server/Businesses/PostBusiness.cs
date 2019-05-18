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

        private static void CheckValid(Post post)
        {
            if (post.Title.Length < 5)
                throw new Error400BadRequest<Post>(
                    "Tiêu đề bài viết phải có nhiều hơn 5 ký tự"
                );

            if (post.Content.Length < 10)
                throw new Error400BadRequest<Post>(
                    "Nội dung bài viết phải có nhiều hơn 10 ký tự"
                );
        }
        public static async Task<Post> Add(Post post, Account accountInDatabase)
        {
            CheckValid(post);
            post.Owner = accountInDatabase;
            return await PostDataAccess.Add(post);
        }

        public static async Task<Post> Update(Post post, Account accountInDatabase)
        {
            var postInDatabase = Get(post.Id);
            if(postInDatabase.Owner.Id != accountInDatabase.Id)
                throw new Error400BadRequest<Post>("Bạn không có quyền chỉnh sửa bài viết này");
                
            CheckValid(post);

            return await PostDataAccess.Update(postInDatabase, post);
        }

        public static async Task Delete(int id)
        {
            await PostDataAccess.Delete(Get(id));
        }
    }
}
