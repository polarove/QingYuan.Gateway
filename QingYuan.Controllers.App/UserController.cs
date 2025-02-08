using Microsoft.AspNetCore.Mvc;
using QingYuan.Services;

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
