using Microsoft.AspNetCore.Mvc;

namespace QingYuan.Controllers.App
{
    public class UserController : QingYuanAppControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("App User");
        }
    }
}
