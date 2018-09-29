using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Constructcode.Web.Persistence
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        private readonly IConfigurationRoot _configuration;
        private readonly IHostingEnvironment _env;

        public DatabaseContextFactory(IConfigurationRoot configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        public DatabaseContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DatabaseContext>();

            if (_env.IsDevelopment())
            {
                builder.UseMySql(_configuration["ConnectionStrings:Development"]);
            }
            else if (_env.IsProduction())
            {
                builder.UseMySql(_configuration["ConnectionStrings:Production"]);
            }

            return new DatabaseContext(builder.Options);
        }
    }
}
