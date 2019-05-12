using System.Linq;
using Realms;
using server.Models.Interface;

namespace server.DataAccesses.Base
{
    public class ModelHasIdDataAccess<TModel> : BaseDataAccess<TModel>
        where TModel : RealmObject, IModelHasId
    {
        public static TModel Get(int id) => Database.Find<TModel>(id);

        protected static int NextId => List.Count() == 0
            ? 1 : List.AsEnumerable().Max(i => i.Id) + 1;
    }
}
