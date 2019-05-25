using server.DataTransfers.PostDataTransfers;
using server.Models;

namespace server.DataTransfers.CommentDataTransfers
{
    public class CommentCreateRequest : BaseDataTransfers<Comment, CommentCreateRequest>
    {
        public PostIdTransfer Post { get; set; }
        public string Content { get; set; }
    }
}
