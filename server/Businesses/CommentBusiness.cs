using System.Linq;
using System.Threading.Tasks;
using server.DataAccesses;
using server.Middleware.Error;
using server.Models;

namespace server.Businesses
{
    public static class CommentBusiness
    {
        public static IQueryable<Comment> List => CommentDataAccess.List;

        public static Comment Get(int id)
        {
            var comment = CommentDataAccess.Get(id);
            if (comment == null) throw new Error404NotFound<Comment>(id);

            return comment;
        }

        private static void CheckValid(Comment comment)
        {
            if (comment.Content.Length < 10)
                throw new Error400BadRequest<Comment>(
                    "Nội dung bình luận phải có ít nhất 10 kí tự"
                );
        }

        public static async Task<Comment> Add(Comment comment, Account account)
        {
            CheckValid(comment);
            comment.Post = comment.Post.GetManaged;
            comment.Owner = account;
            return await CommentDataAccess.Add(comment);
        }

        public static async Task<Comment> Update(Comment comment, Account account)
        {
            var commentInDatabase = Get(comment.Id);
            if (comment.IsOwner(account))
                throw new Error400BadRequest<Comment>("Bạn không có quyền chỉnh sửa bình luận này");

            CheckValid(comment);

            return await CommentDataAccess.Update(commentInDatabase, comment);
        }

        public static async Task Delete(int id, Account account)
        {
            var comment = Get(id);
            // Admin hoặc người đăng bài viết được phép xóa
            if (comment.IsOwner(account))
                throw new Error400BadRequest<Comment>("Bạn không có quyền xóa bình luận này");

            await CommentDataAccess.Delete(comment);
        }
    }
}
