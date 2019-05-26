using blog.server.DataTransfers.PostDataTransfers;
using blog.server.Models;

namespace blog.server.DataTransfers.CommentDataTransfers
{
    public class CommentCreateRequest : BaseDataTransfers<Comment, CommentCreateRequest>
    {
        public PostIdTransfer Post { get; set; }
        public string Content { get; set; }
    }
}
