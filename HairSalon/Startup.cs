using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;//necesarry to call the usemysql method
using HairSalon.Models;//in order to use <HairSalonContext>

namespace HairSalon
{
  public class Startup
  {
    public Startup(IWebHostEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      services.AddEntityFrameworkMySql()
        .AddDbContext<HairSalonContext>(options => options
        .UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionPage();
      app.UseRouting();
      app.UseEndpoints(routes =>
      {
        routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
      });
      
      app.UseStaticFiles(); //allows us to use static files like images
      
      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Page not found!");
      });
    }
  }

}