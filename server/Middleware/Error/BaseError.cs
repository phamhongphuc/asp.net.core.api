using System;
using System.Net;

namespace server.Middleware.Error
{
    public abstract class BaseError : Exception
    {
        public string Description { get; set; }

        public abstract string Model { get; }

        public abstract HttpStatusCode StatusCode { get; }
    }
}
