using System;
using Realms;
using server.Businesses;
using server.Models.Interfaces;

namespace server.Models
{
    public class Comment : RealmObject, IModelHasId
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Content { get; set; }

        public Account Owner { get; set; }
        public Post Post { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
    }
}
