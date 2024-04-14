using Moody.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moody.Services.Services.Abstractions
{
    public interface IMoodService
    {
        Task<IEnumerable<MoodDTO>> GetAllMoodsAsync();
        Task<MoodDTO> GetMoodByIdAsync(int moodId);
        Task<MoodDTO> GetMoodByTypeAsync(string moodType);
        Task CreateMoodAsync(MoodDTO mood);
        Task UpdateMoodAsync(MoodDTO mood);
        Task DeleteMoodByIdAsync(int moodId);
        

    }
}
