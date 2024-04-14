using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moody.Data.Data;
using Moody.Data.Repositories;
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
    public class DailyService : IDailyService
    {
        private readonly IRepository<Daily> _repository;
        

        private readonly IMapper _mapper;
        public DailyService(IRepository<Daily> repository, IMapper mapper, IRepository<Mood> moodRepository, IUserRepository userRepository)
        {
            _repository = repository;
            _mapper = mapper;
            
        }
        public async Task CreateDailyAsync(DailyDTO daily)
        {
            var dailyEntity = _mapper.Map<Daily>(daily);
            await _repository.AddAsync(dailyEntity);
        }

        public async Task DeleteDailyByIdAsync(int dailyId)
        {
            await _repository.DeleteByIdAsync(dailyId);
        }

        public async Task<IEnumerable<DailyDTO>> GetAllDailiesAsync()
        {
            var dailies = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DailyDTO>>(dailies);
        }

        public async Task<IEnumerable<DailyDTO>> GetAllDailiesByUserAsync(string userId)
        {
            var dailies = await _repository.GetAsync(d => d.UserId == userId);
            return _mapper.Map<IEnumerable<DailyDTO>>(dailies);
        }

        public async Task<DailyDTO> GetDailyByIdAsync(int dailyId)
        {
            return _mapper.Map<DailyDTO>(await _repository.GetByIdAsync(dailyId));
        }

        public async Task UpdateDailyAsync(DailyDTO daily)
        {
            var dailyEntity = _mapper.Map<Daily>(daily);
            await _repository.UpdateAsync(dailyEntity);
        }

        //public async Task<IEnumerable<MoodDTO>> GetAllMoodsAsync()
        //{
        //    var moods = await _moodRepository.GetAllAsync();
        //    return _mapper.Map<IEnumerable<MoodDTO>>(moods);
        //}

        //public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        //{
        //    var users = await _userRepository.GetAllUsersAsync();
        //    return _mapper.Map<IEnumerable<UserDTO>>(users);
        //}

        public async Task<DailyDTO> GetDailyByMoodIdAsync(int moodId)
        {
            return _mapper.Map<DailyDTO>(await _repository.GetByIdAsync(moodId));
        }

        public async Task<IEnumerable<DailyDTO>> GetAllDailiesByMoodIdAsync(int moodId)
        {
            var dailies = await _repository.GetAsync(d => d.MoodId == moodId);
            return _mapper.Map<IEnumerable<DailyDTO>>(dailies);
        }

       
    }
}
