using bluesoftbank.DataAccess;
using bluesoftbank.Models;
using bluesoftbank.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// captura de movimiento
builder.Services.AddScoped<MovimientoAccess>();
builder.Services.AddScoped<MovimientoService>();
// conexion de datos

builder.Services.AddDbContext<BluesoftBankContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionstring")));


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
