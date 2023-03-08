using Alura.SubastaOnline.WebApp.Data;
using Alura.SubastaOnline.WebApp.Data.EFCore;
using Alura.SubastaOnline.WebApp.Services;
using Alura.SubastaOnline.WebApp.Services.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.SubastaOnline.WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISubastasDao, SubastasDaoConEFCore>();
            services.AddTransient<ICategoriaDao, CategoriasDaoConEFCore>();
            services.AddTransient<IProductoServices, DefaultProductoServices>();
            services.AddTransient<IAdminServices, ArchivarSubastaService>();
            services.AddDbContext<AppDbContext>();
            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options => 
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePagesWithRedirects("/Home/StatusCode/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
