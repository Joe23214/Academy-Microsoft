using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen; 

namespace ApiTest1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Controller API
            builder.Services.AddControllers();

            // 2. OpenAPI / Swagger
            // builder.Services.AddOpenApi(); // non può essere usato insieme a Swagger classico

            // Swagger classico (compatibile con Swashbuckle) 
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // 3. DbContext (EF Core)
            builder.Services.AddDbContext<ScuolaContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
            );

            // 4. Repository pattern
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IStudenteRepository, StudenteRepository>();
            builder.Services.AddScoped<ICorsoRepository, CorsoRepository>();
            builder.Services.AddScoped<IDocenteRepository, DocenteRepository>();

            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAll", builder =>
            //        builder.AllowAnyOrigin()
            //               .AllowAnyMethod()
            //               .AllowAnyHeader());
            //});
            var app = builder.Build();
            app.UseCors("AllowAll");
            // 5. Swagger attivo in Development
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                //     app.MapOpenApi();     // non può essere usato insieme a Swagger classico
            }

            // 6. Pipeline API
            app.UseHttpsRedirection();
            app.UseAuthorization();


            //AppDomain.CurrentDomain.FirstChanceException += (sender, e) =>
            //{
            //    Console.WriteLine("EXCEPTION: " + e.Exception.GetType().FullName);
            //    Console.WriteLine(e.Exception.Message);
            //};

            // 7. Routing API
            app.MapControllers();

            app.Run();
        }
    }
}
