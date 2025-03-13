using Mapster;
using Microsoft.AspNetCore.Mvc;
using QingYuan.Dto.User;
using QingYuan.Model.Tables;
using QingYuan.Mvc;
using QingYuan.Services;

namespace QingYuan.Controllers.App
{
    //[ControllerAffix("User", null, EnumControllerAffixEffect.Remove)]
    public class UserController(IUserService userService) : QingYuanAppControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponseResult>> Create([FromBody] CreateUserParamDto dto)
        {
            var model = dto.Adapt<User>();
            var result = await userService.CreateAsync(model);
            return ApiResponseResult.Success(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponseResult>> Get([FromRoute] long id)
        {
            var model = await userService.GetAsync(id);
            return ApiResponseResult.Success(model);
        }
    }
}
