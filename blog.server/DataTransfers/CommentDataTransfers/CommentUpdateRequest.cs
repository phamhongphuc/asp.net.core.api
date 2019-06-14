using System.ComponentModel.DataAnnotations;
using blog.server.Models;

namespace blog.server.DataTransfers.CommentDataTransfers
{
    public class CommentUpdateRequest : BaseDataTransfers<Comment, CommentUpdateRequest>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
