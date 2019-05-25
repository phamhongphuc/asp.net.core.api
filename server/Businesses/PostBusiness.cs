using System;
using System.Linq;
using System.Threading.Tasks;
using server.DataAccesses;
using server.Middleware.Error;
using server.Models;
using server.Models.Enums;

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
        public static async Task<Post> Add(Post post, Account account)
        {
            CheckValid(post);
            post.Owner = account;

            return await PostDataAccess.Add(post);
        }

        public static async Task<Post> Update(Post post, Account account)
        {
            var postInDatabase = post.GetManaged;
            if (!postInDatabase.IsOwner(account))
                throw new Error403Forbidden<Post>("Bạn không có quyền chỉnh sửa bài viết này");

            CheckValid(post);

            return await PostDataAccess.Update(postInDatabase, post);
        }

        public static async Task Delete(int id, Account account)
        {
            var post = Get(id);
            var conditionOfAdmin = account.Access == EnumAccess.Administrator;
            var conditionOfMod = post.IsOwner(account);

            if (!(conditionOfAdmin || conditionOfMod))
                throw new Error403Forbidden<Post>("Bạn không có quyền xóa bài viết này");

            await PostDataAccess.Delete(post);
        }
    }
}
