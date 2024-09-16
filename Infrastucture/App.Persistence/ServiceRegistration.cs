using App.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            ConfigurationManager manager = new(); // Nuget Microsoft.Extensions.Configuration and Microsoft.Extensions.Configuration.Json
            manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/App.API"));
            manager.AddJsonFile("appsettings.json");
             
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(manager.GetConnectionString("Default")));
        }
    }
}
