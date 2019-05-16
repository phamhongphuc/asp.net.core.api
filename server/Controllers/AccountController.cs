using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using server.Businesses;
using server.DataTransfers.AccountDataTransfers;
using server.Middleware;
using server.Models;

namespace server.Controllers
{
    /// <summary>
    /// Account Controller
    /// </summary>
    [SwaggerTag(
        "Account",
        Description = "Quản lý hành động của tài khoản"
    )]
    public class AccountController : BaseController
    {
        /// <summary>
        /// Lấy danh sách các tài khoản
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<AccountResponse>> Index()
            => AccountResponse.List(AccountBusiness.List);

        /// <summary>
        /// Đăng ký mới một tài khoản
        /// </summary>
        /// <param name="account">Thông tin tài khoản</param>
        /// <response code="201">Thành công</response>
        /// <response code="400">BadRequest</response>[HttpPost]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountResponse>> Register([FromBody] AccountRequest account)
        {
            var response = await AccountBusiness.Add((Account)account);
            return CreatedAtAction(nameof(Register), (AccountResponse)response);
        }

        /// <summary>
        /// Đổi mật khẩu cho tài khoản
        /// </summary>
        /// <param name="account">Thông tin mật khẩu</param>
        /// <response code="204">Đổi mật khẩu thành công</response>
        /// <response code="404">Không tìm thấy</response>
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangePassword([FromBody] AccountPasswordRequest account)
        {
            await AccountBusiness.ChangePassword(account);
            return NoContent();
        }
    }
}
