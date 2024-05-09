using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Entities.Interface;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Extensions;
using Backend.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.CustomConfigurations(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<SkillEntity, SkillIncludedDTO>, SkillRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    if (!app.Configuration.GetValue<bool>("Database:Cv:UsingMigration"))
    {
        app.NoMigration(app.Configuration.GetValue<bool>("DataBase:Cv:RecreateDatabase"));
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();