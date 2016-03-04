using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Web.Services.Domain
{
    public class BaseDomain<TEntity> where TEntity : class
    {
        protected ApplicationDbContext _context;

        public BaseDomain(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }
    }
}
