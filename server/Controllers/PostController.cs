using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Realms;
using server.Models;

namespace server.Controllers
{
    /// <summary>
    /// Post Controller
    /// </summary>
    [SwaggerTag(
        "Post",
        Description = "Quản lý hành động của đối tượng bài đăng"
    )]
    public class PostController : BaseController
    {
        private Realm realm => Realm.GetInstance();
        private IQueryable<Post> list => realm.All<Post>();
        private int nextId => list.Count() == 0 ? 1 : list.AsEnumerable().Max(p => p.Id) + 1;

        /// <summary>
        /// Trả về một danh sách các bài viết
        /// </summary>
        [HttpGet]
        public ActionResult<List<Post>> Index() => list.ToList();

        /// <summary>
        /// Lấy một bài đăng
        /// </summary>
        /// <param name="id">Id bài viết</param>
        /// <response code="200">Tìm thấy</response>
        /// <response code="404">Không tìm thấy</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult<Post> Item(int id)
        {
            var post = realm.Find<Post>(id);
            if (post == null) return NotFound("Item not found");
            return post;
        }

        /// <summary>
        /// Đăng một bài viết mới, và trả về bài viết đó
        /// </summary>
        /// <response code="201">Thành công</response>
        [HttpPost]
        public async Task<ActionResult<Post>> Post()
        {
            var post = new Post()
            {
                Id = nextId,
                Content = "Content",
                Title = " Title",
                Created = new DateTimeOffset()
            };
            await realm.WriteAsync(r => post = r.Add(post));
            return CreatedAtAction(nameof(Post), post);
        }
    }
}
