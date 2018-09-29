using Constructcode.Web.Core.Domain;
using Constructcode.Web.Persistence.EntityConfigurations;
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

        public DatabaseContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PostCategoryConfigurations.Config(modelBuilder);
            CategoryConfigurations.Config(modelBuilder);
            PostConfigurations.Config(modelBuilder);
            MessageConfigurations.Config(modelBuilder);
            AccountConfigurations.Config(modelBuilder);
        }
    }
}