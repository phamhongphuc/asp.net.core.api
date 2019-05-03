using System;
using Microsoft.AspNetCore.Mvc;
using Realms;

namespace server.Models
{
    public class Post : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Content { get; set; }
    }
}