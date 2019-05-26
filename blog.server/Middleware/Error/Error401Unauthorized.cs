using System;
using System.Net;
using Realms;
using blog.server.Models.Interfaces;

namespace blog.server.Middleware.Error
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
