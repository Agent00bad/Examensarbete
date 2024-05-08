using Backend.API.Database;
using Backend.API.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.CustomConfigurations(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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