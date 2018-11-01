using Constructcode.Web.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Constructcode.Web.Persistence.EntityConfigurations
{
    public static class CategoryConfigurations
    {
        public static void Config(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Categories");

            modelBuilder.Entity<Category>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
