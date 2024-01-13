using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace HorseMoney.Infrastructure.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
    
            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "HorseMoney.Presentation"));
            
   
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();


            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

  
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

      
            optionsBuilder.LogTo(Console.WriteLine);


            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}