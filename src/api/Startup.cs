namespace api
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            if(config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var responseTest = _config
                .GetSection(ApplicationOptions.TestSection)
                .Get<ApplicationOptions>()
                .TestResponse;
                
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(responseTest);
            });
        }
    }
}
