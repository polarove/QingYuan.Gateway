using Microsoft.AspNetCore.Mvc;
using QingYuan.Common;

namespace QingYuan.Controllers.Admin
{
    public class AccountController : QingYuanAdminControllerBase
    {
        [HttpGet("login")]
        public ActionResult<ApiResponseResult> SignInAsync()
        {
            return Ok(ApiResponseResult.Success(1));
        }
    }
}
