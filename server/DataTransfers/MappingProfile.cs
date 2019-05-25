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
