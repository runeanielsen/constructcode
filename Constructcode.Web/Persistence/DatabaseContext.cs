using Constructcode.Web.Core.Domain;
using Constructcode.Web.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Constructcode.Web.Persistence
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<PostCategory> PostCategories { get; set; }

        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _configuration;

        public DatabaseContext(IHostingEnvironment env, IConfigurationRoot configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PostCategoryConfigurations.Config(modelBuilder);
            CategoryConfigurations.Config(modelBuilder);
            PostConfigurations.Config(modelBuilder);
            MessageConfigurations.Config(modelBuilder);
            AccountConfigurations.Config(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_env.IsDevelopment())
            {
                optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:Development"]);
            }
            else if(_env.IsProduction())
            {
                optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:Production"]);
            }         
        }
    }
}