﻿using System;
using System.Net;

namespace blog.server.Middleware.Error
{
    public abstract class BaseErrorGeneric<TModel> : BaseError
    {
        public override string Model => typeof(TModel).Name;

        public override abstract HttpStatusCode StatusCode { get; }
    }
}
