using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using StartupProject_Asp.NetCore_PostGRE.Data.Models;

namespace StartupProject_Asp.NetCore_PostGRE
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //IP Address Reading support
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(
                        IPAddress.Parse(Configuration.GetSection("ApplicationIP").Value)
                    );
            });

            services.AddDbContext<ApplicationDbContext>(options => {
                if (Environment.IsDevelopment())
                {
                    options.UseNpgsql(Configuration.GetConnectionString("DevelopConnection"));
                }
                else
                {
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
                }
            });

            services.AddDefaultIdentity<ApplicationUser>(options => {
                    if (Environment.IsDevelopment())
                    {
                        options.SignIn.RequireConfirmedAccount = true;
                        // Password settings
                        options.Password.RequireDigit = false;
                        options.Password.RequiredLength = 4;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireLowercase = false;
                    }
                    else
                    {
                        options.Password.RequiredLength = 8;
                    }
                })
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddUserManager<UserManager<ApplicationUser>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            /*
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            */

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                //options.ExcludedHosts.Add("example.com");
                //options.ExcludedHosts.Add("www.example.com");
            });

            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            //    options.HttpsPort = 5001;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //IWebHostEnvironment env - Can be removed
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();  //Can be ignored
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //        name: "auth",
                //        pattern: "auth/{controller=Account}/{action=Register}/{id?}"
                //    );

                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapRazorPages();
            });
        }
    }
}
