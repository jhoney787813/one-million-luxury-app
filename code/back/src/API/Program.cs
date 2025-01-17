using API.Extensions;
using Application;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddApplicationLayer();
builder.Services.AddDomainLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.RegisterSwagger();

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("*")  // Permitir solicitudes desde el frontend
              .AllowAnyHeader()                      // Permitir cualquier encabezado
              .AllowAnyMethod();                     // Permitir cualquier método (GET, POST, etc.)
    });
});

builder.Services.AddControllers();

var app = builder.Build();
app.UseCors("AllowLocalhost");
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BFF.Backend.Million.App v1"));

app.UseAuthorization();

app.MapControllers();
app.UseAuthorization();

app.Run();

