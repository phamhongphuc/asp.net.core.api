using System;
using Realms;
using blog.server.Businesses;
using blog.server.Middleware.Error;
using blog.server.Models.Interfaces;

namespace blog.server.Models
{
    public class Comment : RealmObject, IModelHasId
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Content { get; set; }

        public Account Owner { get; set; }
        public Post Post { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }

        public Boolean IsOwner(Account account) => Owner.Id == account.Id;

        [Ignored]
        public Comment GetManaged
        {
            get
            {
                var comment = CommentBusiness.Get(Id);
                if (comment == null) throw new Error404NotFound<Comment>(Id);
                return comment;
            }
        }
    }
}
