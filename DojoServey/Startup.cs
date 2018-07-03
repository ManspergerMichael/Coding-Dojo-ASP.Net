using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DojoServey
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseStaticFiles();
            app.UseMvc();
        }
        public Startup(IHostingEnvironment env)
        {
            // run this in the debugger, and inspect the "env" object! 	You can use this object to tell you 
			// the root path of your application, for the purposes of reading from local files, and for
            // checking environment variables - such as if you are running in Development or Production
            
            Console.WriteLine(env.ContentRootPath);
            Console.WriteLine(env.IsDevelopment());
        }

    }
}
