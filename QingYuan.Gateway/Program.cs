using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QingYuan.Gateway.Middlewares;
using QingYuan.Gateway.ModelConvention;
using QingYuan.Services;
using QingYuan.Services.EF;
using QingYuan.Services.EF.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddApplicationPart(typeof(ControllerBase).Assembly);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));


builder.Services.AddScoped<IUserService, UserServiceImpl>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(c =>
    {
        c.AllowAnyOrigin();
        c.AllowAnyHeader();
    });
});


builder.Services.AddMvc(x =>
{
    x.Conventions.Add(new ControllerAffixAttributeConvention());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<HttpNotFoundMiddleware>();

app.Run();
