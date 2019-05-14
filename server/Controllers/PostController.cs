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
using server.Middleware;
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
        public ActionResult<List<PostResponse>> Index()
            => PostResponse.List(PostBusiness.List);

        /// <summary>
        /// Lấy một bài viết
        /// </summary>
        /// <param name="id">Id bài viết</param>
        /// <response code="200">Tìm thấy</response>
        /// <response code="404">Không tìm thấy</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public ActionResult<PostResponse> Item(int id) => (PostResponse)PostBusiness.Get(id);

        /// <summary>
        /// Đăng một bài viết mới
        /// </summary>
        /// <param name="post">Nội dung một bài đăng</param>
        /// <response code="201">Thành công</response>
        /// <response code="400">BadRequest</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostResponse>> Post([FromBody] PostRequest post)
        {
            var response = await PostBusiness.Add((Post)post);
            return CreatedAtAction(nameof(Post), (PostResponse)response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostResponse>> Update([FromBody] PostUpdateRequest post)
        {
            var response = await PostBusiness.Update((Post)post);
            return (PostResponse)response;
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await PostBusiness.Delete(id);
            return NoContent();
        }
    }
}
