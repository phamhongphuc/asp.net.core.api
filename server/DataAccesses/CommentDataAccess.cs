using System;
using System.Threading.Tasks;
using server.DataAccesses.Base;
using server.Models;

namespace server.DataAccesses
{
    public class CommentDataAccess : ModelHasIdDataAccess<Comment>
    {
        public static async Task<Comment> Add(Comment comment)
        {
            await Database.WriteAsync(realm =>
            {
                comment.Id = NextId;
                comment.Created = DateTimeOffset.Now;
                comment.Modified = null;
                comment = realm.Add(comment);
            });
            return comment;
        }

        public static async Task<Comment> Update(Comment commentInDatabase, Comment comment)
        {
            await Database.WriteAsync(realm =>
            {
                commentInDatabase.Content = comment.Content;
                commentInDatabase.Modified = DateTimeOffset.Now;
            });
            return commentInDatabase;
        }

        public static async Task Delete(Comment comment)
        {
            await Database.WriteAsync(realm => realm.Remove(comment));
        }
    }
}
