using Constructcode.Web.Core.Domain;
using Constructcode.Web.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

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

        public DatabaseContext(IHostingEnvironment env)
        {
            _env = env;
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
                optionsBuilder.UseSqlServer( @"Server=(localdb)\MSSQLLocalDB;Database=constructcodedb;Trusted_Connection=True;");
            }
            else if(_env.IsProduction())
            {
                optionsBuilder.UseSqlServer(@"Data Source=constructcode.database.windows.net;Initial Catalog=constructcodedb;Integrated Security=False;User ID=runeanielsen;Password=RzqpvyPUfOGNwhse7yAu;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }         
        }
    }
}