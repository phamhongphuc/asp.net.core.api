using System;
using System.ComponentModel.DataAnnotations;
using blog.server.DataTransfers.AccountDataTransfers;
using blog.server.DataTransfers.PostDataTransfers;
using blog.server.Models;

namespace blog.server.DataTransfers.CommentDataTransfers
{
    public class CommentResponse : BaseDataTransfers<Comment, CommentResponse>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public AccountSimpleResponse Owner { get; set; }

        [Required]
        public PostIdTransfer Post { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; }

        public DateTimeOffset? Modified { get; set; }
    }
}
