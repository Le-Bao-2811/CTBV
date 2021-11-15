using CongTyBaoVe.Web.Entites;
using CongTyBaoVe.Web.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web
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
			services.AddControllersWithViews();
			services.AddScoped<LoginRepository>();
			services.AddScoped<ChucVuRepository>();
			services.AddScoped<NhanVienRepository>();
			services.AddAuthentication("Cookies")
				.AddCookie(options =>
				{
					options.LoginPath = "/Login";   // đường dẫn trang đăng nhập
					options.ExpireTimeSpan = TimeSpan.FromHours(6); // tự đăng xuất sau 6h
					options.Cookie.HttpOnly = true; // lý do bảo mật
				});
			services.AddDbContext<CongTyBaoVeDbContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("CongTyBaoVe"));
			});
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
			app.UseCookiePolicy();
			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "Login",
					pattern: "login",
					defaults: new { controller = "User", action = "Login" });
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
