using server.Models;

namespace server.DataTransfers.PostDataTransfers
{
    public class PostUpdateRequest : BaseDataTransfers<Post, PostUpdateRequest>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
    }
}
