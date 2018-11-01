using Constructcode.Web.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Constructcode.Web.Persistence.EntityConfigurations
{
    public static class MessageConfigurations
    {
        public static void Config(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>().ToTable("Messages");

            modelBuilder.Entity<Message>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
