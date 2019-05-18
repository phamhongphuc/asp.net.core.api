using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using server.Businesses;
using server.DataTransfers.CommentDataTransfers;
using server.Middleware;
using server.Models;

namespace server.Controllers
{
    /// <summary>
    /// Comment Controller
    /// </summary>
    [SwaggerTag(
        "Comment",
        Description = "Quản lý hành động của đối tượng bình luận"
    )]

    [Authorize]
    public class CommentController : BaseController
    {
        /// <summary>
        /// Lấy danh sách các bình luận
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<CommentResponse>> Index()
            => CommentResponse.List(CommentBusiness.List);

        /// <summary>
        /// Lấy một bình luận
        /// </summary>
        /// <param name="id">Id bình luận</param>
        /// <response code="200">Tìm thấy</response>
        /// <response code="404">Không tìm thấy</response>
        [AllowAnonymous]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public ActionResult<CommentResponse> Item(int id) => (CommentResponse)CommentBusiness.Get(id);

        /// <summary>
        /// Đăng một bình luận mới
        /// </summary>
        /// <param name="comment">Nội dung bình luận</param>
        /// <response code="201">Thành công</response>
        /// <response code="400">BadRequest</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CommentResponse>> Create([FromBody] CommentRequest comment)
        {
            var response = await CommentBusiness.Add((Comment)comment, CurrentUser);
            return CreatedAtAction(nameof(Create), (CommentResponse)response);
        }

        /// <summary>
        /// Sửa một bình luận
        /// </summary>
        /// <param name="comment">Nội dung bình luận</param>
        /// <response code="200">Thành công</response>
        /// <response code="400">BadRequest</response>
        /// <response code="404">Không tìm thấy</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CommentResponse>> Update([FromBody] CommentUpdateRequest comment)
        {
            var response = await CommentBusiness.Update((Comment)comment, CurrentUser);
            return (CommentResponse)response;
        }

        /// <summary>
        /// Xóa một bình luận
        /// </summary>
        /// <param name="id">Id bình luận</param>
        /// <response code="204">Xóa thành công</response>
        /// <response code="404">Không tìm thấy</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await CommentBusiness.Delete(id, CurrentUser);
            return NoContent();
        }
    }
}
