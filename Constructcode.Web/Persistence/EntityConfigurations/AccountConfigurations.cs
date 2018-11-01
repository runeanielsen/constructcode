using Constructcode.Web.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Constructcode.Web.Persistence.EntityConfigurations
{
    public static class AccountConfigurations
    {
        public static void Config(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Accounts");

            modelBuilder.Entity<Account>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
