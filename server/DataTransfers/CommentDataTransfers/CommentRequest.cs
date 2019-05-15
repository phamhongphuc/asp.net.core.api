using server.Models;

namespace server.DataTransfers.CommentDataTransfers
{
    public class CommentRequest : BaseDataTransfers<Comment, CommentRequest>
    {
        public string Content { get; set; }
    }
}