using System;
using System.Collections.Generic;
using AutoMapper;
using Realms;
using server.DataTransfers.PostDataTransfers;
using server.Models;

namespace server.DataTransfers
{
    public class BaseDataTransfers<TModel, TData>
        where TData : BaseDataTransfers<TModel, TData>
    {
        public static implicit operator BaseDataTransfers<TModel, TData>(TModel model)
            => Mapper.Map<TModel, TData>(model) as BaseDataTransfers<TModel, TData>;

        public static List<TData> List(IEnumerable<TModel> models)
            => Mapper.Map<IEnumerable<TModel>, List<TData>>(models);
    }
}
