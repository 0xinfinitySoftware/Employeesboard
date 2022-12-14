using Employeesboard.Shared.Candidates;
using Employeesboard.Shared.Database;

namespace Employeesboard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ICandidatesFinder, CandidatesFinder>();
            string connString = builder.Configuration.GetConnectionString("Default").Replace("\"", string.Empty);
            builder.Services.AddScoped<IConnectionFactory, MysqlConnectionFactory>(b => new MysqlConnectionFactory(connString));

            var app = builder.Build();
            app.Urls.Add("http://localhost:12345");

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