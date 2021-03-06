using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kudvenkat.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace kudvenkat
{
  public class Startup
  {
    private IConfiguration _config;

    public Startup(IConfiguration config)
    {
      _config = config;
    }


    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));

      services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

      /*services.Configure<IdentityOptions>(options =>
      {
        options.Password.RequiredLength = 10;
        options.Password.RequiredUniqueChars = 3;
        options.Password.RequireNonAlphanumeric = false;
      });*/

      services.AddMvc().AddXmlSerializerFormatters() ;
      // services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
      services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        // app.UseDeveloperExceptionPage();
         app.UseStatusCodePagesWithReExecute("/Error/{0}");
        // app.UseExceptionHandler("/Error");
      }
      else
      {
        // app.UseStatusCodePagesWithRedirects("/Error/{0}");
        // app.UseStatusCodePagesWithReExecute("/Error/{0}");
        app.UseExceptionHandler("/Error");
      }

      app.UseStaticFiles();

      app.UseAuthentication();

      // 3.0 modification
      // https://stackoverflow.com/questions/57684093/using-usemvc-to-configure-mvc-is-not-supported-while-using-endpoint-routing
      app.UseRouting();
      app.UseCors();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
