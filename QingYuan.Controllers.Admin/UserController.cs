using Microsoft.AspNetCore.Mvc;

namespace QingYuan.Controllers.Admin
{
    public class UserController : QingYuanAdminControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Admin User");
        }
    }
}
