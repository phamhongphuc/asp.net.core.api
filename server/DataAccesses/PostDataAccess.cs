using System.Linq;
using System.Threading.Tasks;
using server.DataAccesses.Base;
using server.Models;

namespace server.DataAccesses
{
    public class PostDataAccess : ModelHasIdDataAccess<Post>
    {
        public static async Task<Post> Add(Post post)
        {
            await Database.WriteAsync(realm =>
            {
                post.Id = NextId;
                post = realm.Add(post);
            });
            return post;
        }
    }
}
