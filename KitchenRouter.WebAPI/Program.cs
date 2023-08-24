using KitchenRouter.Domain.Models;
using KitchenRouter.Domain.Repositories.Interfaces;
using KitchenRouter.Infrastructure.Context;
using KitchenRouter.Infrastructure.Repositories;
using KitchenRouter.WebAPI.Middlewares;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => 
    {
        // I want enum to be sent and received as string, not int
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); 
    });
builder.Services.AddDbContext<KitchenRouterContext>(
    opt => opt.UseInMemoryDatabase("KitchenRouter"));
builder.Services.AddScoped<IRepository<Order>, Repository<Order>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware(typeof(ExcpetionHandlerMiddleware));

app.MapControllers();

app.Run();
