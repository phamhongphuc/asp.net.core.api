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
            CreateMap<PostRequest, Post>();
            CreateMap<PostUpdateRequest, Post>();
        }

        private void MappingComment()
        {
            CreateMap<Comment, CommentResponse>();
            CreateMap<CommentRequest, Comment>();
            CreateMap<CommentUpdateRequest, Comment>();
        }

        private void MappingAccount()
        {
            CreateMap<Account, AccountResponse>();
            CreateMap<AccountRequest, Account>();
            CreateMap<AccountPasswordRequest, Account>();
        }
    }
}
