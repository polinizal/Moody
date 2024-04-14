using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Moody.Data.Data;
using Moody.Data.Repositories.Abstractions;
using Moody.Services.DTOs;
using Moody.Services.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moody.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _repository.GetAllUsersAsync(); 
            return _mapper.Map<IEnumerable<UserDTO>>(users);

        }

        public async Task<UserDTO> GetUserByIdAsync(string id)
        {
            var user = await _repository.GetUserByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

    }
}
