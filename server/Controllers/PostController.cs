using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Realms;
using server.Businesses;
using server.DataTransfers.PostDataTransfers;
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
        /// <summary>
        /// Lấy danh sách các bài viết
        /// </summary>
        [HttpGet]
        public ActionResult<List<Post>> Index() => PostBusiness.List.ToList();

        /// <summary>
        /// Lấy một bài viết
        /// </summary>
        /// <param name="id">Id bài viết</param>
        /// <response code="200">Tìm thấy</response>
        /// <response code="404">Không tìm thấy</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult<PostResponse> Item(int id) => (PostResponse)PostBusiness.Get(id);

        /// <summary>
        /// Đăng một bài viết mới
        /// </summary>
        /// <param name="post">Nội dung một bài đăng</param>
        /// <response code="201">Thành công</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(PostResponse), StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<PostResponse>> Post([FromBody] Post post)
        {
            post = await PostBusiness.Add(post);
            return CreatedAtAction(nameof(Post), (PostResponse)post);
        }
    }
}
