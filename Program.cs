using E_Commerce.DbContext;
using E_Commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Inject Db
            builder.Services.AddDbContext<AppDbContext>
                (
                option => option.
                UseSqlServer( builder.Configuration.GetConnectionString("DBConnection"))
                );

            //Inject Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();



            builder.Services.AddScoped<ProductBL>();
            builder.Services.AddScoped<CreateAdmin>();
            builder.Services.AddScoped<CartBL>();


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var c = scope.ServiceProvider
                    .GetRequiredService<CreateAdmin>();

                ApplicationUser u = new ApplicationUser
                {
                    UserName = "DoniaEid",
                    Email = "doniaeid815@gmail.com"
                };

                await c.CreateAdmintoapplication(u, "1234");
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
