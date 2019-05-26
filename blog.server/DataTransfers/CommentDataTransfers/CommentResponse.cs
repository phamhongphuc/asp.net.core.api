using System;
using blog.server.DataTransfers.AccountDataTransfers;
using blog.server.DataTransfers.PostDataTransfers;
using blog.server.Models;

namespace blog.server.DataTransfers.CommentDataTransfers
{
    public class CommentResponse : BaseDataTransfers<Comment, CommentResponse>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public AccountIdTransfer Owner { get; set; }
        public PostIdTransfer Post { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
    }
}
