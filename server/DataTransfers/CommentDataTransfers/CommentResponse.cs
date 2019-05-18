using System;
using server.DataTransfers.AccountDataTransfers;
using server.DataTransfers.PostDataTransfers;
using server.Models;

namespace server.DataTransfers.CommentDataTransfers
{
    public class CommentResponse : BaseDataTransfers<Comment, CommentResponse>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public AccountIdResponse Owner { get; set; }
        public PostIdTransfer Post { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
    }
}
