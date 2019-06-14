using System.ComponentModel.DataAnnotations;
using blog.server.Models;

namespace blog.server.DataTransfers.PostDataTransfers
{
    public class PostCreateRequest : BaseDataTransfers<Post, PostCreateRequest>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Cover { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
