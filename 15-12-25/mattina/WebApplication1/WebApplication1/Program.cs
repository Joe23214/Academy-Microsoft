using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Repositories;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ScuolaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection(); 
app.UseStaticFiles();       
app.UseRouting();           
app.UseAuthorization();


/*
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Studente}/{action=Index}/{id?}");

*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
