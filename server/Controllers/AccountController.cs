using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using server.Authentication;
using server.Businesses;
using server.Controllers.Base;
using server.DataTransfers.AccountDataTransfers;
using server.Middleware;
using server.Models;
using server.Models.Enums;

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
        [Authorize(Policy = nameof(EnumAccess.Moderator))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<AccountResponse>> List()
            => AccountResponse.List(AccountBusiness.List);

        /// <summary>
        /// Lấy thông tin của một tài khoản
        /// </summary>
        /// <param name="id">Id tài khoản</param>
        /// <response code="200">Tìm thấy</response>
        /// <response code="404">Không tìm thấy</response>
        [HttpGet("{id:int}")]
        [Authorize(Policy = nameof(EnumAccess.BannedUser))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public ActionResult<AccountResponse> GetById(int id) => (AccountResponse)AccountBusiness.Get(id);

        /// <summary>
        /// Lấy thông tin tài khoản của chính mình
        /// </summary>
        /// <response code="200">Tìm thấy</response>
        [HttpGet("me")]
        [Authorize(Policy = nameof(EnumAccess.BannedUser))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<AccountResponse> Me() => (AccountResponse)User.Account();

        /// <summary>
        /// Đổi mật khẩu cho tài khoản
        /// </summary>
        /// <param name="request">Thông tin mật khẩu</param>
        /// <response code="204">Đổi mật khẩu thành công</response>
        /// <response code="404">Không tìm thấy</response>
        [HttpPatch(nameof(ChangePassword))]
        [Authorize(Policy = nameof(EnumAccess.BannedUser))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangePassword([FromBody] AccountChangePasswordRequest request)
        {
            await AccountBusiness.ChangePassword(User.Account(), request);
            return NoContent();
        }

        /// <summary>
        /// Chỉnh Sửa thông tin tài khoản
        /// </summary>
        /// <param name="account">Thông tin tài khoản</param>
        /// <response code="200">Thành công</response>
        /// <response code="400">BadRequest</response>
        /// <response code="404">Không tìm thấy</response>
        [HttpPut]
        [Authorize(Policy = nameof(EnumAccess.BannedUser))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountResponse>> Update([FromBody] AccountUpdateRequest account)
        {
            var response = await AccountBusiness.Update(User.Account(), (Account)account);
            return (AccountResponse)response;
        }

        /// <summary>
        /// Phân quyền, cập nhật quyền
        /// </summary>
        /// <param name="request">Thông tin tài khoản và quyền mới</param>
        /// <response code="204">Đổi mật khẩu thành công</response>
        /// <response code="404">Không tìm thấy</response>
        [HttpPatch(nameof(UpdateAccess))]
        [Authorize(Policy = nameof(EnumAccess.Administrator))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAccess([FromBody] AccountUpdateAccessRequest request)
        {
            await AccountBusiness.UpdateAccess(request);
            return NoContent();
        }

        /// <summary>
        /// Đăng ký mới một tài khoản
        /// </summary>
        /// <param name="account">Thông tin tài khoản</param>
        /// <response code="201">Thành công</response>
        /// <response code="400">BadRequest</response>
        [HttpPost(nameof(Register))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountResponse>> Register([FromBody] AccountCreateRequest account)
        {
            var response = await AccountBusiness.Register((Account)account);
            return CreatedAtAction(nameof(Register), (AccountResponse)response);
        }

        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="account">Thông tin đăng nhập</param>
        /// <response code="201">Thành công</response>
        /// <response code="400">BadRequest</response>
        [HttpPost(nameof(Login))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<AccountLoginResponse> Login([FromBody] AccountLoginRequest account)
        {
            var response = AccountBusiness.Login((Account)account);
            return CreatedAtAction(nameof(Login), response);
        }
    }
}
