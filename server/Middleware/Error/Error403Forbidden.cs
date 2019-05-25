using System;
using System.Net;
using Realms;
using server.Models.Interfaces;

namespace server.Middleware.Error
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
