using Constructcode.Web.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Constructcode.Web.Persistence.EntityConfigurations
{
    public static class PostConfigurations
    {
        public static void Config(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Posts");

            modelBuilder.Entity<Post>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
