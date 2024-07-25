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


// 
builder.Services.AddScoped<MovimientoAccess>();
builder.Services.AddScoped<MovimientoService>();

builder.Services.AddScoped<ClienteAccess>();
builder.Services.AddScoped<ClienteService>();


builder.Services.AddScoped<TipoDeMovimientoAccess>();
builder.Services.AddScoped<TipoDeMovimientoService>();

builder.Services.AddScoped<TipoDePersonaAccess>();
builder.Services.AddScoped<TipoDePersonaService>();

builder.Services.AddScoped<TipoDeCuentaAccess>();
builder.Services.AddScoped<TipoDeCuentaService>();




// conexion de datos

builder.Services.AddDbContext<BluesoftBankContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionstring")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactJSDomain", policy => policy.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
    .WithExposedHeaders("content-disposition")
    );
});


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


app.UseCors("ReactJSDomain");

app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );

app.Run();
