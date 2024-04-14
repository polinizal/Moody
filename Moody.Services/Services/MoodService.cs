using AutoMapper;
using Moody.Data.Data;
using Moody.Data.Repositories.Abstractions;
using Moody.Services.DTOs;
using Moody.Services.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Moody.Services.Services
{
    public class MoodService : IMoodService
    {
        private readonly IRepository<Mood> _repository;
        private readonly IMapper _mapper;
        public MoodService(IRepository<Mood> repository, IMapper mapper)
        {
                _repository = repository;
                _mapper = mapper;
        }

        public async Task CreateMoodAsync(MoodDTO mood)
        {
            var moodEntity = _mapper.Map<Mood>(mood);
            await _repository.AddAsync(moodEntity);

        }

        public async Task DeleteMoodByIdAsync(int moodId)
        {
            await _repository.DeleteByIdAsync(moodId);
        }

        public async Task<IEnumerable<MoodDTO>> GetAllMoodsAsync()
        {
            var moods = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MoodDTO>>(moods);
        }

        public async Task<MoodDTO> GetMoodByIdAsync(int moodId)
        {
            return _mapper.Map<MoodDTO>(await _repository.GetByIdAsync(moodId));
        }

        public async Task<MoodDTO> GetMoodByTypeAsync(string moodType)
        {
            var mood = await _repository.GetAsync(m => m.MoodType == moodType);
            return _mapper.Map<MoodDTO>(mood.FirstOrDefault());
        }

        public async Task UpdateMoodAsync(MoodDTO mood)
        {
            var moodEntity = _mapper.Map<Mood>(mood);
            await _repository.UpdateAsync(moodEntity);
        }
    }
}
