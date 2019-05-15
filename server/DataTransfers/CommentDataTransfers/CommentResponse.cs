using System;
using server.Models;

namespace server.DataTransfers.CommentDataTransfers
{
    public class CommentResponse : BaseDataTransfers<Comment, CommentResponse>
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
    }
}
