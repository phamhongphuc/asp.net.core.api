using System.ComponentModel.DataAnnotations;
using blog.server.DataTransfers.PostDataTransfers;
using blog.server.Models;

namespace blog.server.DataTransfers.CommentDataTransfers
{
    public class CommentCreateRequest : BaseDataTransfers<Comment, CommentCreateRequest>
    {
        [Required]
        public PostIdTransfer Post { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
