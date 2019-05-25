using System;
using System.Net;
using Realms;
using server.Models.Interfaces;

namespace server.Middleware.Error
{
    public class Error404NotFound<TModel> : BaseErrorGeneric<TModel>
        where TModel : RealmObject, IModelHasId
    {
        public Error404NotFound(int id) : base()
        {
            Description = $"Không tìm thấy <{Model}> có id là [{id}]";
        }

        public Error404NotFound(string email) : base()
        {
            Description = $"Không tìm thấy <{Model}> có email là [{email}]";
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    }
}
