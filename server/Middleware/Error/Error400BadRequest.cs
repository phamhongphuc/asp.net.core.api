using System;
using System.Net;
using Realms;
using server.Models.Interfaces;

namespace server.Middleware.Error
{
    public class Error400BadRequest<TModel> : BaseErrorGeneric<TModel>
        where TModel : RealmObject
    {
        public Error400BadRequest(string message) : base()
        {
            Description = message;
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}
