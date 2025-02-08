using Microsoft.AspNetCore.Mvc;
using QingYuan.Services;

namespace QingYuan.Controllers.App
{
    public class UserController(IUserService userService) : QingYuanAppControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await userService.Create();
            return Ok("App User");
        }
    }
}
