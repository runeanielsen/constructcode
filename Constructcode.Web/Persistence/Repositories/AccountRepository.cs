using Constructcode.Web.Core.Domain;
using Constructcode.Web.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Constructcode.Web.Persistence.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public DatabaseContext DatabaseContext => Context as DatabaseContext;

        public AccountRepository(DbContext context) : base(context)
        {
        }
    }
}
