using Microsoft.EntityFrameworkCore;
using BibliotecaCarlosMeridaAPI.Data;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.Net;
using BibliotecaCarlosMeridaAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

var app = builder.Build();

// Usar el middleware personalizado para manejar excepciones
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1"));
}

app.UseHttpsRedirection();

// Aplicar la pol�tica de CORS
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();

app.Run();
