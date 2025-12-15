using Microex.Swagger.SwaggerGen.Application;
using Microsoft.EntityFrameworkCore;
using ScuolaAPIServer.Data;
using ScuolaAPIServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<ScuolaDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// repository
builder.Services.AddScoped<IStudenteRepository, StudenteRepository>();
builder.Services.AddScoped<IProfessoreRepository, ProfessoreRepository>();
builder.Services.AddScoped<ICorsoRepository, CorsoRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Controllers
builder.Services.AddControllers();

// Swagger
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

app.MapControllers();

app.Run();
