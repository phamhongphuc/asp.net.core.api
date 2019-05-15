using System.Collections.Generic;
using System.Threading.Tasks;
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
    public class CommentController : BaseController
    {
        /// <summary>
        /// Lấy danh sách các bình luận
        /// </summary>
        [HttpGet]
        public ActionResult<List<CommentResponse>> Index()
            => CommentResponse.List(CommentBusiness.List);

        /// <summary>
        /// Lấy một bình luận
        /// </summary>
        /// <param name="id">Id bình luận</param>
        /// <response code="200">Tìm thấy</response>
        /// <response code="404">Không tìm thấy</response>
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
        public async Task<ActionResult<CommentResponse>> Comment([FromBody] CommentRequest comment)
        {
            var response = await CommentBusiness.Add((Comment)comment);
            return CreatedAtAction(nameof(Comment), (CommentResponse)response);
        }

        /// <summary>
        /// Sửa một bình luận
        /// </summary>
        /// <param name="comment">Nội dung bình luận</param>
        /// <response code="400">BadRequest</response>
        /// <response code="404">Không tìm thấy</response>
        [HttpPut]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CommentResponse>> Update([FromBody] CommentUpdateRequest comment)
        {
            var response = await CommentBusiness.Update((Comment)comment);
            return (CommentResponse)response;
        }

        /// <summary>
        /// Xóa một bình luận
        /// </summary>
        /// <param name="id">Id bình luận</param>
        /// <response code="204">Xóa thành công</response>
        /// <response code="404">Không tìm thấy</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await CommentBusiness.Delete(id);
            return NoContent();
        }
    }
}