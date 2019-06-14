using System.Linq;
using System.Threading.Tasks;
using blog.server.DataAccesses;
using blog.server.Middleware.Error;
using blog.server.Models;
using blog.server.Models.Enums;

namespace blog.server.Businesses
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
            if (comment.Content.Length < 3)
                throw new Error400BadRequest<Comment>(
                    "Nội dung bình luận phải có ít nhất 3 kí tự"
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
            if (!commentInDatabase.IsOwner(account))
                throw new Error403Forbidden<Comment>("Bạn không có quyền chỉnh sửa bình luận này");

            CheckValid(comment);

            return await CommentDataAccess.Update(commentInDatabase, comment);
        }

        public static async Task Delete(int id, Account account)
        {
            var comment = Get(id);

            var conditionOfAdmin = account.Access == EnumAccess.Administrator;

            var conditionOfMod = account.Access == EnumAccess.Moderator &&
            (EnumAccess.BannedUser | EnumAccess.NormalUser).HasFlag(comment.Owner.Access);

            var conditionOfNormal = comment.IsOwner(account);

            if (!(conditionOfAdmin || conditionOfMod || conditionOfNormal))
                throw new Error403Forbidden<Comment>("Bạn không có quyền xóa bình luận này");

            await CommentDataAccess.Delete(comment);
        }
    }
}
