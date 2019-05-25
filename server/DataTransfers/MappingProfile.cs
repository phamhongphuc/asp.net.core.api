using System;
using AutoMapper;
using server.DataTransfers.AccountDataTransfers;
using server.DataTransfers.PostDataTransfers;
using server.Models;

namespace server.DataTransfers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MappingPost();
            MappingAccount();
        }

        private void MappingPost()
        {
            CreateMap<Post, PostResponse>();
            CreateMap<Post, PostIdTransfer>().ReverseMap();
            CreateMap<PostCreateRequest, Post>();
            CreateMap<PostUpdateRequest, Post>();
        }
        private void MappingAccount()
        {
            CreateMap<Account, AccountResponse>();
            CreateMap<Account, AccountIdTransfer>().ReverseMap();
            CreateMap<AccountLoginRequest, Account>();
            CreateMap<AccountCreateRequest, Account>();
            CreateMap<AccountUpdateRequest, Account>();
        }
    }
}
