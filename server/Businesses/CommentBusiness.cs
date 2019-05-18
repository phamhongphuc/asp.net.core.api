using System;
using System.Linq;
using System.Threading.Tasks;
using server.DataAccesses;
using server.DataTransfers.CommentDataTransfers;
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

        public static async Task<Comment> Add(Comment comment, Account accountInDatabase)
        {
            CheckValid(comment);
            comment.Post = PostBusiness.Get(comment.Post.Id);
            comment.Owner = accountInDatabase;
            return await CommentDataAccess.Add(comment);
        }

        public static async Task<Comment> Update(Comment comment)
        {
            var commentInDatabase = Get(comment.Id);
            CheckValid(comment);

            return await CommentDataAccess.Update(commentInDatabase, comment);
        }

        public static async Task Delete(int id)
        {
            await CommentDataAccess.Delete(Get(id));
        }
    }
}
