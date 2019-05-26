using System;
using System.Net;
using Realms;
using blog.server.Models.Interfaces;

namespace blog.server.Middleware.Error
{
    public class Error403Forbidden<TModel> : BaseErrorGeneric<TModel>
        where TModel : RealmObject
    {
        public Error403Forbidden(string message) : base()
        {
            Description = message;
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;
    }
}
