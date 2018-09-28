using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ASPNETCORERoleManagement.Data;
using ASPNETCORERoleManagement.Models;
using ASPNETCORERoleManagement.Services;
using Microsoft.AspNetCore.Http;

namespace ASPNETCORERoleManagement
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

			//Password Strength Setting  
			services.Configure<IdentityOptions>(options =>
			{
				// Password settings  
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 8;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = true;
				options.Password.RequireLowercase = false;
				options.Password.RequiredUniqueChars = 6;

				// Lockout settings  
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
				options.Lockout.MaxFailedAccessAttempts = 10;
				options.Lockout.AllowedForNewUsers = true;

				// User settings  
				options.User.RequireUniqueEmail = true;
			});

			//Seting the Account Login page  
			services.ConfigureApplicationCookie(options =>
			{
				// Cookie settings  
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
				options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login  
				options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout  
				options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied  
				options.SlidingExpiration = true;
			});


			services.AddTransient<MenuMasterService, MenuMasterService>();

			// Add application services.
			services.AddTransient<IEmailSender, EmailSender>();

            // servicio agregado por gpg
            services.AddScoped<IRepositorioBukrs, BukrsRepositorioEF>();
            
            services.AddMvc();


            // agrego las sesiones para el gpocia
            // Adds a default in-memory implementation of IDistributedCache.
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.Cookie.Name = "SessionGpoCia";
                //HttpContext.Session.GetString(SessionGpoCia);
                options.IdleTimeout = TimeSpan.FromSeconds(1800);
                options.Cookie.HttpOnly = true;
            });
            // hasta aqui agregue
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env , IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            // agrego para sesion
            app.UseSession();
            //hasta aqui
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

			CreateUserRoles(services).Wait();

		}


		private async Task CreateUserRoles(IServiceProvider serviceProvider)
		{
			var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


			IdentityResult roleResult;
			//Adding Addmin Role  
			var roleCheck = await RoleManager.RoleExistsAsync("Admin");
			if (!roleCheck)
			{
				//create the roles and seed them to the database  
				roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
			}

			roleCheck = await RoleManager.RoleExistsAsync("Manager");
			if (!roleCheck)
			{
				//create the roles and seed them to the database  
				roleResult = await RoleManager.CreateAsync(new IdentityRole("Manager"));
			}

			//Assign Admin role to the main User here we have given our newly loregistered login id for Admin management  
			ApplicationUser user = await UserManager.FindByEmailAsync("gabymid@hotmail.com");
			var User = new ApplicationUser();
			await UserManager.AddToRoleAsync(user, "Admin");


			user = await UserManager.FindByEmailAsync("ritagabrielap@gmail.com");
			await UserManager.AddToRoleAsync(user, "Manager");

		}
	}
}
