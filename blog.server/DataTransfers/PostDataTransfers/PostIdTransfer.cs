using System.ComponentModel.DataAnnotations;
using blog.server.Models;

namespace blog.server.DataTransfers.PostDataTransfers
{
    public class PostIdTransfer : BaseDataTransfers<Post, PostIdTransfer>
    {
        [Required]
        public int Id { get; set; }
    }
}
