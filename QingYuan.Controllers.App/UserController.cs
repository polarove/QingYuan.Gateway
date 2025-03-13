﻿using Microsoft.AspNetCore.Mvc;
using QingYuan.Dto;
using QingYuan.Dto.User;
using QingYuan.Mvc;
using QingYuan.Services;

namespace QingYuan.Controllers.App
{
    //[ControllerAffix("User", null, EnumControllerAffixEffect.Remove)]
    public class UserController(IUserService userService) : QingYuanAppControllerBase
    {

        [HttpPost("create")]
        public async Task<ActionResult<ApiResponseResult>> Create([FromBody] CreateUserParamDto dto)
        {
            var result = await userService.CreateAsync(dto);
            return ApiResponseResult.Success(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult<ApiResponseResult>> Delete([FromBody] IdDto dto)
        {
            var model = await userService.DeleteAsync(dto.Id);
            return ApiResponseResult.Success(model);
        }


        [HttpPost("update")]
        public async Task<ActionResult<ApiResponseResult>> Update([FromBody] UpdateUserParamDto dto)
        {
            var result = await userService.UpdateAsync(dto);
            return ApiResponseResult.Success(result);
        }

        [HttpGet("detail/{id}")]
        public async Task<ActionResult<ApiResponseResult>> Detail([FromRoute] long id)
        {
            var model = await userService.GetAsync(id);
            return ApiResponseResult.Success(model);
        }

        [HttpPost("list")]
        public async Task<ActionResult<ApiResponseResult>> List([FromBody] QueryUserParamDto dto)
        {
            var result = await userService.GetAsync(dto);
            return ApiResponseResult.Success(result);
        }

    }
}
