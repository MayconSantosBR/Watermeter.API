using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Watermeter.Project.API;
using Watermeter.Project.API.Data.Contexts;
using Watermeter.Project.API.Data.Repositories;
using Watermeter.Project.API.Data.Repositories.Interfaces;
using Watermeter.Project.API.Models;
using Watermeter.Project.API.Models.Profiles;
using Watermeter.Project.API.Services;
using Watermeter.Project.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Entity Framework Core
builder.Services.AddDbContext<MainContext>(option =>
{
    option.UseNpgsql(EnviromentConfig.Hosts.MainDb);
});

//Identity
builder.Services.AddDbContext<UserContext>(option =>
{
    option.UseNpgsql(EnviromentConfig.Hosts.MainDb);
});
builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(
    options => options.SignIn.RequireConfirmedEmail = true)
    .AddEntityFrameworkStores<UserContext>()
    .AddDefaultTokenProviders(); //For confirmation tokens, ex: register a new email.

    //Identity options
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
});

//Mapper
builder.Services.AddAutoMapper(typeof(MapperService));

//Services
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IArduinoRepository, ArduinoRepository>();
builder.Services.AddScoped<IArduinoService, ArduinoService>();

builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IOwnerService, OwnerService>();

builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();
builder.Services.AddScoped<IHistoryService, HistoryService>();

builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
