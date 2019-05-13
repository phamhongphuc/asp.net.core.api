using System;
using Microsoft.AspNetCore.Mvc;
using Realms;
using server.Models.Interfaces;

namespace server.Models
{
    public class Post : RealmObject, IModelHasId
    {
        /// <summary>Khóa chính - Định danh của một bài đăng</summary>
        [PrimaryKey]
        public int Id { get; set; }

        /// <summary>Tiêu đề của bài đăng</summary>
        public string Title { get; set; }

        /// <summary>Thời gian đăng bài (được ghi lại ở phía máy chủ)</summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>Nội dung của bài viết, được viết bằng ngôn ngữ markdown-+</summary>
        public string Content { get; set; }
    }
}
