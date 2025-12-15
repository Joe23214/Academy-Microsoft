using System.Net.Http.Headers;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // MVC
            builder.Services.AddControllersWithViews();

            // HttpClient nominato per parlare col backend Web API
            builder.Services.AddHttpClient("ScuolaApi", client =>
            {
                // URL base del tuo server Web API (modifica porta e schema se diverso)
                client.BaseAddress = new Uri("https://localhost:7153/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }); // uso di IHttpClientFactory consigliato in ASP.NET Core [web:48][web:52]


            var app = builder.Build();

            // Pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Static assets (template .NET 9+)
            app.MapStaticAssets();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
