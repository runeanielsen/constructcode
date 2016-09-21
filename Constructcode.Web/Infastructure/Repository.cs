using Constructcode.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Constructcode.Web.Infastructure
{
    public class Repository : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
