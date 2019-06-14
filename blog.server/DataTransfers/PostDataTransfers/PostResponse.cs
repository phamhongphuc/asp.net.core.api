using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using blog.server.DataTransfers.AccountDataTransfers;
using blog.server.DataTransfers.CommentDataTransfers;
using blog.server.Models;

namespace blog.server.DataTransfers.PostDataTransfers
{
    public class PostResponse : BaseDataTransfers<Post, PostResponse>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Cover { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public AccountSimpleResponse Owner { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; }

        public DateTimeOffset? Modified { get; set; }

        [Required]
        public List<CommentResponse> Comments { get; set; }
    }
}
