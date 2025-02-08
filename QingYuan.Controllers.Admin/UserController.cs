using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using QingYuan.Common;
using QingYuan.Dto.User;
using QingYuan.Model.Tables;
using QingYuan.Services;

namespace QingYuan.Controllers.Admin
{
    public class UserController(IUserService userService) : QingYuanAdminControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult<ApiResponseResult>> CreateAsync([FromBody] CreateUserParamDto dto)
        {
            var user = dto.Adapt<User>();
            var id = await userService.CreateAsync(user);
            return Ok(ApiResponseResult.Success(id));
        }

        [HttpPost("edit")]
        public async Task<ActionResult<ApiResponseResult>> UpdateAsync([FromBody] UpdateUserParamDto dto)
        {
            var user = dto.Adapt<User>();
            var id = await userService.UpdateAsync(user);
            return Ok(ApiResponseResult.Success(id));
        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult<ApiResponseResult>> DeleteAsync([FromRoute] long id)
        {
            var result = await userService.DeleteAsync(id);
            return Ok(ApiResponseResult.Success(result));
        }

        [HttpGet("detail/{id}")]
        public async Task<ActionResult<ApiResponseResult<QueryUserResultDto>>> GetAsync([FromRoute] int id)
        {
            var user = await userService.GetAsync(id);
            var dto = user.Adapt<QueryUserResultDto>();
            return Ok(ApiResponseResult.Success(dto));
        }

        [HttpGet("list")]
        public async Task<ActionResult<ApiResponseResult>> GetAsync([FromQuery] QueryUserParamDto dto)
        {
            var user = await userService.GetAsync(dto);
            return Ok(user);
        }
    }
}
