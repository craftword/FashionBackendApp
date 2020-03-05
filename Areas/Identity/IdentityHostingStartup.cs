using System;
using FashionBackendApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FashionBackendApp.Areas.Identity.IdentityHostingStartup))]
namespace FashionBackendApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FashionBackendAppIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FashionBackendAppIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<FashionBackendAppIdentityDbContext>();
            });
        }
    }
}