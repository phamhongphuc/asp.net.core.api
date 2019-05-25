using System;
using System.Net;
using Realms;
using server.Models.Interfaces;

namespace server.Middleware.Error
{
    public class Error401Unauthorized<TModel> : BaseErrorGeneric<TModel>
        where TModel : RealmObject
    {
        public Error401Unauthorized(string message) : base()
        {
            Description = message;
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
    }
}
