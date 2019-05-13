using System;
using AutoMapper;
using server.DataTransfers.PostDataTransfers;
using server.Models;

namespace server.DataTransfers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MappingPost();
        }

        private void MappingPost()
        {
            CreateMap<Post, PostResponse>();
        }
    }
}
