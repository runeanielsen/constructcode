using Constructcode.Web.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Constructcode.Web.Persistence.EntityConfigurations
{
    public static class PostCategoryConfigurations
    {
        public static void Config(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostCategory>().ToTable("PostCategories");

            modelBuilder.Entity<PostCategory>()
                .HasKey(t => new { t.PostId, t.CategoryId });

           modelBuilder.Entity<PostCategory>()
                .HasOne(pc => pc.Post)
                .WithMany(pc => pc.PostCategories)
                .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<PostCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(pc => pc.PostCategories)
                .HasForeignKey(pt => pt.CategoryId);
        }
    }
}
