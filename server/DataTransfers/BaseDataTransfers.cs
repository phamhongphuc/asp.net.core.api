using System;
using System.Collections.Generic;
using AutoMapper;
using Realms;
using server.DataTransfers.PostDataTransfers;
using server.Models;

namespace server.DataTransfers
{
    public class BaseDataTransfers<TSrc, TDes>
        where TDes : BaseDataTransfers<TSrc, TDes>
    {
        public static implicit operator BaseDataTransfers<TSrc, TDes>(TSrc model)
            => Mapper.Map<TSrc, TDes>(model) as BaseDataTransfers<TSrc, TDes>;

        public static explicit operator TSrc(BaseDataTransfers<TSrc, TDes> des)
            => Mapper.Map<BaseDataTransfers<TSrc, TDes>, TSrc>(des);

        public static List<TDes> List(IEnumerable<TSrc> models)
            => Mapper.Map<IEnumerable<TSrc>, List<TDes>>(models);
    }
}
