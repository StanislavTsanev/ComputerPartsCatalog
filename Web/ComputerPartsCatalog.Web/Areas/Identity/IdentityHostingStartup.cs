using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ComputerPartsCatalog.Web.Areas.Identity.IdentityHostingStartup))]
namespace ComputerPartsCatalog.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}