using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UkwWypozyczalnia.DAL;
using UkwWypozyczalnia.Models;

namespace UkwWypozyczalnia
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddIdentity<User, Role>(options =>
			{
				options.User.RequireUniqueEmail = true;



				options.Password.RequiredLength = 3;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;

				options.Lockout.MaxFailedAccessAttempts = 4;
				options.Lockout.DefaultLockoutTimeSpan = System.TimeSpan.FromMinutes(1);
			}).AddEntityFrameworkStores<IdentityAppContext>();
			services.AddControllersWithViews();
			services.AddDbContext<FilmsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("db")));
			services.AddDbContext<IdentityAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("db")));
			services.AddSession();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseSession();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "Categories",
					pattern: "Category/{categoryName}",
					defaults: new { controller = "Films", action = "FilmsList" }
					);

				endpoints.MapControllerRoute(
					name: "StaticSite",
					pattern: "Info/{name}",
					defaults: new { controller = "Home", actions = "StaticSite" }
					);

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
