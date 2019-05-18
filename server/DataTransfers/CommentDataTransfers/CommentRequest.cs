using server.DataTransfers.PostDataTransfers;
using server.Models;

namespace server.DataTransfers.CommentDataTransfers
{
    public class CommentRequest : BaseDataTransfers<Comment, CommentRequest>
    {
        public PostIdTransfer Post { get; set; }
        public string Content { get; set; }
    }
}
