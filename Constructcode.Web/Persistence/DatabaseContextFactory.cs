using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Constructcode.Web.Persistence
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DatabaseContext>();

            builder.UseMySql("Server=mysql31.unoeuro.com;Database=constructcode_com_db;Uid=constructc_com;Pwd=60bfec51442dab3bbf1e3e740e06041d;");

            return new DatabaseContext(builder.Options);
        }
    }
}
