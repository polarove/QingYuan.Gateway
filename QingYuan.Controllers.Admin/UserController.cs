using Microsoft.AspNetCore.Mvc;
using QingYuan.Services;

namespace QingYuan.Controllers.Admin
{
    public class UserController(IUserService userService) : QingYuanAdminControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> CreateAsync()
        {
            await userService.CreateAsync();
            return Ok(userService.GetHashCode());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync([FromRoute] int id)
        {
            var user = await userService.GetAsync(id);
            return Ok(user);
        }
    }
}
