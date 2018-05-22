
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using vega.Persistence;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace vega
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
            services.AddAutoMapper();
            // services.AddDbContext<VegaDbContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddDbContext<VegaDbContext>(Options => Options.UseSqlServer("Data Source=localhost; Initial Catalog=vega; Integrated Security=SSPI;"));
            // services.AddDbContext<VegaDbContext>(Options => Options.UseSqlServer("Data Source=PK6539\\SQL2014; Initial Catalog=vega; Integrated Security=SSPI;"));
            // services.AddDbContext<VegaDbContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("Data Source=PK6539\\SQL2014; Initial Catalog=vega; Integrated Security=SSPI;"));
            // "Data Source=PK6539\\SQL2014; Initial Catalog=vega; Integrated Security=SSPI;"
            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // loggerFactory.AddConsole(Configuration.GetSection(logging));
            // loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
