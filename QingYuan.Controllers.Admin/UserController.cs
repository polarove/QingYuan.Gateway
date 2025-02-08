using Microsoft.AspNetCore.Mvc;
using QingYuan.Services;

namespace QingYuan.Controllers.Admin
{
    public class UserController(IUserService userService) : QingYuanAdminControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await userService.Create();
            return Ok(userService.GetHashCode());
        }
    }
}
