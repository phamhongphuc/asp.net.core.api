using System;
using AutoMapper;
using server.DataTransfers.AccountDataTransfers;
using server.DataTransfers.CommentDataTransfers;
using server.DataTransfers.PostDataTransfers;
using server.Models;

namespace server.DataTransfers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MappingPost();
            MappingComment();
            MappingAccount();
        }

        private void MappingPost()
        {
            CreateMap<Post, PostResponse>();
            CreateMap<Post, PostIdTransfer>().ReverseMap();
            CreateMap<PostCreateRequest, Post>();
            CreateMap<PostUpdateRequest, Post>();
        }

        private void MappingComment()
        {
            CreateMap<Comment, CommentResponse>();
            CreateMap<CommentCreateRequest, Comment>();
            CreateMap<CommentUpdateRequest, Comment>();
        }

        private void MappingAccount()
        {
            CreateMap<Account, AccountResponse>();
            CreateMap<Account, AccountIdResponse>();
            CreateMap<AccountCreateRequest, Account>();
            CreateMap<AccountUpdateRequest, Account>();
        }
    }
}
