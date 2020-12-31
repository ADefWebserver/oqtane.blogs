using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Oqtane.Infrastructure;
using WilderMinds.MetaWeblog;

namespace Oqtane.Blogs.Server.Startup
{
    public class ServerStartup : IServerStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMetaWeblog<MetaWeblogService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMetaWeblog("/MetaWeblog");
        }

        public void ConfigureMvc(IMvcBuilder mvcBuilder)
        {
        }
    }
}
