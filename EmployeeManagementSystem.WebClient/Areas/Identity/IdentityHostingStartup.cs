using System;
using EmployeeManagementSystem.WebClient.Core.Entities;
using EmployeeManagementSystem.WebClient.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EmployeeManagementSystem.WebClient.Areas.Identity.IdentityHostingStartup))]
namespace EmployeeManagementSystem.WebClient.Areas.Identity
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