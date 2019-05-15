using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using server.Businesses;
using server.DataTransfers.AccountDataTransfers;
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
        public ActionResult<List<AccountResponse>> Index()
            => AccountResponse.List(AccountBusiness.List);

        /// <summary>
        /// Đăng ký mới một tài khoản
        /// </summary>
        /// <param name="account">Thông tin tài khoản</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<AccountResponse>> Register([FromBody] AccountRequest account)
        {
            var response = await AccountBusiness.Add((Account)account);
            return CreatedAtAction(nameof(Register), (AccountResponse)response);
        }
    }
}
