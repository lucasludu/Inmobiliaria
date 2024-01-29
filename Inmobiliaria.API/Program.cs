using Inmobiliaria.Models.Mapper;
using Inmobiliaria.Negocio.Repos;
using Inmobiliaria.Negocio.Repos.Interfaces;
using Inmobiliaria.Negocio.UOW;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(InmoMapp));


builder.Services.AddScoped<IPropiedadNegocio, PropiedadNegocio>();
builder.Services.AddScoped<IUbicacionNegocio, UbicacionNegocio>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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
