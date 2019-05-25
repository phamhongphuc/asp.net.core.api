using server.Models;

namespace server.DataTransfers.PostDataTransfers
{
    public class PostRequest : BaseDataTransfers<Post, PostRequest>
    {
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
    }
}
