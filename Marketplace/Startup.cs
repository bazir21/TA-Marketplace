using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Marketplace.Services;
using Marketplace.Data;
using Marketplace.Models;
using Marketplace.Roles;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Marketplace
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
            services.AddDbContext<MarketplaceContext>(options => 
                    options.UseMySql(Configuration.GetConnectionString("MarketplaceConnection"), new MariaDbServerVersion(new Version(10, 5, 9)),
                        mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)));

            services.AddDatabaseDeveloperPageExceptionFilter(); //The AddDatabaseDeveloperPageExceptionFilter provides helpful error information in the development environment.
            services.AddControllersWithViews();
            services.AddTransient<JsonFileInstructor>();
            services.AddTransient<JsonFileModuleService>();
            services.AddTransient<BidService>();
            services.AddTransient<InstructorService>();
            services.AddTransient<ModuleInstructorListService>();
            services.AddTransient<AdminService>();
            services.AddTransient<LoginService>();
            services.AddTransient<UserService>();


            //Authentication
            // services.AddDefaultIdentity<IdentityUser>(options =>
            //     options.SignIn.RequireConfirmedAccount = true)
            //     .AddRoles<IdentityRole>()
            //     .AddEntityFrameworkStores<MarketplaceContext>();
                
                services.AddIdentity<UserModel, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<MarketplaceContext>();
                
                services.AddIdentityCore<InstructorModel>()
                .AddDefaultTokenProviders()
                .AddRoles<InstructorRole>()
                .AddEntityFrameworkStores<MarketplaceContext>();

                services.AddIdentityCore<AdministratorModel>()
                .AddDefaultTokenProviders()
                .AddRoles<AdministratorRole>()
                .AddEntityFrameworkStores<MarketplaceContext>();

                services.Configure<IdentityOptions>(options =>
                {
                    // Password settings.
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;

                    // Lockout settings.
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    // User settings.
                    options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = true;
                });

                services.ConfigureApplicationCookie(options =>
                {
                    // Cookie settings
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                    options.LoginPath = "/Identity/Account/Login";
                    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                    options.SlidingExpiration = true;
                });


            //Authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                    policy=> policy.RequireRole("AdministratorRole"));
                
                options.AddPolicy("RequireElevatedRole",
                    policy=> policy.RequireRole("AdministratorRole", "Lecturer")); //Foundation for lecturer rights

                options.AddPolicy("RequireInstructorRole",
                    policy=> policy.RequireRole("InstructorRole"));

                // options.FallbackPolicy = new AuthorizationPolicyBuilder()
                //     .RequireAuthenticatedUser()
                //     .Build();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
