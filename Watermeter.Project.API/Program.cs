using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Watermeter.Project.API;
using Watermeter.Project.API.Data.Context;
using Watermeter.Project.API.Data.Repositories;
using Watermeter.Project.API.Entities;
using Watermeter.Project.API.Models;
using Watermeter.Project.API.Models.Profiles;
using Watermeter.Project.API.Services;
using Watermeter.Project.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MainContext>(option =>
{
    option.UseNpgsql(EnviromentConfig.Hosts.MainDb);
});

builder.Services.AddAutoMapper(typeof(MapperService));

builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IArduinoService, ArduinoService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();

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
