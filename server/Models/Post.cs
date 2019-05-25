using System;
using System.Linq;
using Realms;
using server.Businesses;
using server.Middleware.Error;
using server.Models.Interfaces;

namespace server.Models
{
    public class Post : RealmObject, IModelHasId
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }

        public Account Owner { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }

        [Backlink(nameof(Comment.Post))]
        public IQueryable<Comment> Comments { get; }

        public Boolean IsOwner(Account account) => Owner.Id == account.Id;

        [Ignored]
        public Post GetManaged
        {
            get
            {
                var post = PostBusiness.Get(Id);
                if (post == null) throw new Error404NotFound<Post>(Id);
                return post;
            }
        }
    }
}
