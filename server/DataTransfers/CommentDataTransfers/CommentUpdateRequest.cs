using server.Models;

namespace server.DataTransfers.CommentDataTransfers
{
    public class CommentUpdateRequest : BaseDataTransfers<Comment, CommentUpdateRequest>
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
