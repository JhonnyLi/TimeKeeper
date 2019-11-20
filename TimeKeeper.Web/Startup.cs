using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using TimeKeeper.Data;
using TimeKeeper.Web.Data;
using TimeKeeper.Web.Models;
using TimeKeeper.Web.Repositorys;

namespace TimeKeeper.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IWebHostEnvironment HostingEnvironment { get; private set; }
        public IConfiguration Configuration { get; private set; }

        private readonly SecretClient _secretClient;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.HostingEnvironment = env;

            string keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME", EnvironmentVariableTarget.User);
            var kvUri = "https://" + keyVaultName + ".vault.azure.net";

            _secretClient = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                var conString = _secretClient.GetSecret("TimeKeeperSqlConnectionString").Value.Value.ToString();
                options.UseSqlServer(conString);
            });

            //Add Idwentity registers the services
            services.AddIdentity<AppUser, AppRole>()
               .AddEntityFrameworkStores<AppDbContext>()
               .AddDefaultTokenProviders();

            services.AddControllersWithViews();

            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            AppDbContext context,
            RoleManager<AppRole> roleManager,
            UserManager<AppUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "bower_components")),
                    RequestPath = "/frameworks"
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            var seed = new SeedData(_secretClient);
            seed.Initialize(context, userManager, roleManager).Wait();
        }
    }
}
