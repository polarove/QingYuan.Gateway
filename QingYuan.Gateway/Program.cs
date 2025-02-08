using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QingYuan.Services;
using QingYuan.Services.EF;
using QingYuan.Services.EF.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddApplicationPart(typeof(ControllerBase).Assembly);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("MySQLConnection") ?? throw new InvalidOperationException(),
    builder => builder.MigrationsAssembly("QingYuan.Gateway"))
    //.EnableSensitiveDataLogging()
    .LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
