using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StartupProject_Asp.NetCore_PostGRE.Data;

[assembly: HostingStartup(typeof(StartupProject_Asp.NetCore_PostGRE.Areas.Identity.IdentityHostingStartup))]
namespace StartupProject_Asp.NetCore_PostGRE.Areas.Identity
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