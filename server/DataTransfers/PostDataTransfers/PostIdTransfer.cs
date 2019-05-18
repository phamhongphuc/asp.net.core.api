using server.Models;

namespace server.DataTransfers.PostDataTransfers
{
    public class PostIdTransfer : BaseDataTransfers<Post, PostIdTransfer>
    {
        public int Id { get; set; }
    }
}
