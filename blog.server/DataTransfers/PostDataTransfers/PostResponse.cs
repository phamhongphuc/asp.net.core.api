using System;
using blog.server.DataTransfers.AccountDataTransfers;
using blog.server.Models;

namespace blog.server.DataTransfers.PostDataTransfers
{
    public class PostResponse : BaseDataTransfers<Post, PostResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public AccountIdTransfer Owner { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
    }
}
