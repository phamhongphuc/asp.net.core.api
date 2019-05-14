using System;
using System.Net;
using Realms;
using server.Models.Interfaces;

namespace server.Middleware.Error
{
    public class Error404NotFound<TModel> : BaseErrorGeneric<TModel>
        where TModel : RealmObject, IModelHasId
    {
        private int Id { get; }

        public Error404NotFound(int id) : base()
        {
            Id = id;
            Description = $"Không tìm thấy <{Model}> có id là [{Id}]";
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    }
}
