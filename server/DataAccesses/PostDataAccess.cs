using System.Linq;
using System.Threading.Tasks;
using server.DataAccesses.Base;
using server.Models;

namespace server.DataAccesses
{
    public class PostDataAccess : RealmDatabase
    {
        public static int NextId => List.Count() == 0
            ? 1 : List.AsEnumerable().Max(i => i.Id) + 1;

        public static IQueryable<Post> List => Database.All<Post>();

        public static Post Get(int id) => Database.Find<Post>(id);

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
