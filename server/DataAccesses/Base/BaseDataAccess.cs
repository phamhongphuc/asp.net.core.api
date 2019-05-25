using System.Linq;
using Realms;

namespace server.DataAccesses.Base
{
    public class BaseDataAccess<TModel> : RealmDatabase
        where TModel : RealmObject
    {
        public static IQueryable<TModel> List => Database.All<TModel>();
    }
}
