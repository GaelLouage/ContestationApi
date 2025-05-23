using Infra.Bootstrapper;
using Infra.Models;
using Infra.Repositories.Classes;
using Infra.Repositories.Interfaces;
using Infra.Services.Classes;
using Infra.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//get connectionstrings
builder.Services.Configure<MongoServicePoptions>(
    builder.Configuration.GetSection("ConnectionStrings")
    );

builder.Services.AddServices();

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
