using System;
using server.Models;

namespace server.DataTransfers.PostDataTransfers
{
    public class PostResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }

        public static implicit operator PostResponse(Post post)
            => new PostResponse()
            {
                Id = post.Id,
                Title = post.Title,
                Cover = post.Cover,
                Content = post.Content,
                Created = post.Created,
                Modified = post.Modified
            };
    }
}
