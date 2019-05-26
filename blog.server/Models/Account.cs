using System;
using System.Linq;
using Realms;
using blog.server.Authentication;
using blog.server.Businesses;
using blog.server.Middleware.Error;
using blog.server.Models.Enums;
using blog.server.Models.Interfaces;

namespace blog.server.Models
{
    public class Account : RealmObject, IModelHasId
    {
        private int Access_ { get; set; }
        private int Gender_ { get; set; }

        [PrimaryKey]
        public int Id { get; set; }
        public string Password { get; set; }
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
            return CryptoHelper.Encrypt(rawPassword).Equals(Password);
        }

        [Ignored]
        public Account GetManagedByEmail => AccountBusiness.GetByEmail(Email);

        [Ignored]
        public Account GetManaged => AccountBusiness.Get(Id);

        [Ignored]
        public Boolean IsPresent => AccountBusiness.GetByEmail(Email) != null;
    }
}
