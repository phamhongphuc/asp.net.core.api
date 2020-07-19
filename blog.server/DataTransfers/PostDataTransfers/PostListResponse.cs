using System;
using System.ComponentModel.DataAnnotations;
using blog.server.DataTransfers.AccountDataTransfers;
using blog.server.Models;

namespace blog.server.DataTransfers.PostDataTransfers
{
    public class PostListResponse : BaseDataTransfers<Post, PostListResponse>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Cover { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
