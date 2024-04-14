using Microsoft.AspNetCore.Identity;
using Moody.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moody.Data.Repositories.Abstractions
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(string id);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
