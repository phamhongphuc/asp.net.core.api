using System;
using AutoMapper;
using blog.server.DataTransfers.AccountDataTransfers;
using blog.server.DataTransfers.CommentDataTransfers;
using blog.server.DataTransfers.PostDataTransfers;
using blog.server.Models;

namespace blog.server.DataTransfers
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
            CreateMap<Account, AccountIdTransfer>().ReverseMap();
            CreateMap<AccountLoginRequest, Account>();
            CreateMap<AccountCreateRequest, Account>();
            CreateMap<AccountUpdateRequest, Account>();
        }
    }
}
