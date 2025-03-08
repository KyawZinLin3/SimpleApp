using SimpleApp.Persistence;
using SimpleApp.Repositories.Implementation;
using SimpleApp.Repositories.Interface;
using System.Data;
using System.Data.SqlClient;

namespace SimpleApp
{
    public class Program
    {
        public static  void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Register Dapper Connection
            builder.Services.Configure<DapperContext>(builder.Configuration.GetSection("DbSettings"));

            //Configure DI for app
            builder.Services.AddSingleton<DapperContext>();
            builder.Services.AddScoped<IProductRepository,ProductRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            //ensure database and table exists?
            using (var scope = app.Services.CreateAsyncScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DapperContext>();

                 context.Init().GetAwaiter().GetResult();
            }
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
