using System;
using server.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Collections;

namespace server.DataTransfers.PostDataTransfers
{
    public class PostRequest : BaseDataTransfers<Post, PostRequest>
    {
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
    }
}
