using System;
using server.Models;

namespace server.DataTransfers.PostDataTransfers
{
    public class PostResponse : BaseDataTransfers<Post, PostResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
    }
}
