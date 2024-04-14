using Microsoft.EntityFrameworkCore;
using Moody.Data.Data;
using Moody.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moody.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);

        }
    }
}
