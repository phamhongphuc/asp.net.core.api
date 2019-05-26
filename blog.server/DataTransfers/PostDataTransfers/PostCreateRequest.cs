using blog.server.Models;

namespace blog.server.DataTransfers.PostDataTransfers
{
    public class PostCreateRequest : BaseDataTransfers<Post, PostCreateRequest>
    {
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
    }
}
