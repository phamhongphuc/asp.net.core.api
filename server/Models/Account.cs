using System;
using System.Linq;
using Realms;
using server.Authentication;
using server.Models.Enums;
using server.Models.Interfaces;

namespace server.Models
{
    public class Account : RealmObject, IModelHasId
    {
        private int Access_ { get; set; }
        private int Gender_ { get; set; }

        [PrimaryKey]
        public int Id { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }

        public EnumAccess Access { get { return (EnumAccess)Access_; } set { Access_ = (int)value; } }
        public EnumGender Gender { get { return (EnumGender)Gender_; } set { Gender_ = (int)value; } }

        public DateTimeOffset Joined { get; set; }

        [Backlink(nameof(Post.Owner))]
        public IQueryable<Post> Posts { get; }

        [Backlink(nameof(Comment.Owner))]
        public IQueryable<Comment> Comments { get; }

        public bool IsEqualPassword(string rawPassword)
        {
            return CryptoHelper.Encrypt(rawPassword).Equals(Pass);
        }
    }
}
