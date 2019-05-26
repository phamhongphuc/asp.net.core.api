using blog.server.Models;

namespace blog.server.DataTransfers.PostDataTransfers
{
    public class PostIdTransfer : BaseDataTransfers<Post, PostIdTransfer>
    {
        public int Id { get; set; }
    }
}
