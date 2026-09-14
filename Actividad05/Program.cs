using Actividad05.Models;
using Microsoft.EntityFrameworkCore;
using Actividad05.Repositories;
using Actividad05.Repositories.Implements;
using Actividad05.Services;
using Actividad05.Services.Implements;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios específicos
builder.Services.AddScoped<IEvaluacionesProveedorRepository, EvaluacionesProveedorRepository>();
builder.Services.AddScoped<IFormulaProduccionRepository, FormulaProduccionRepository>();
builder.Services.AddScoped<IInspeccionesCalidadRepository, InspeccionesCalidadRepository>();
builder.Services.AddScoped<IMateriasPrimaRepository, MateriasPrimaRepository>();
builder.Services.AddScoped<IMovimientosInventarioRepository, MovimientosInventarioRepository>();
builder.Services.AddScoped<IOrdenesProduccionRepository, OrdenesProduccionRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProveedoreRepository, ProveedoreRepository>();

// Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Servicios específicos
builder.Services.AddScoped<IEvaluacionesProveedorService, EvaluacionesProveedorService>();
builder.Services.AddScoped<IFormulaProduccionService, FormulaProduccionService>();
builder.Services.AddScoped<IInspeccionesCalidadService, InspeccionesCalidadService>();
builder.Services.AddScoped<IMateriasPrimaService, MateriasPrimaService>();
builder.Services.AddScoped<IMovimientosInventarioService, MovimientosInventarioService>();
builder.Services.AddScoped<IOrdenesProduccionService, OrdenesProduccionService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProveedoreService, ProveedoreService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Actividad 05");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();