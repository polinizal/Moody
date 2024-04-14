using Moody.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moody.Services.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByIdAsync(string id);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
       
    }
}
