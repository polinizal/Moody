using Moody.Data.Data;
using Moody.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moody.Services.Services.Abstractions
{
    public interface IDailyService
    {
        Task<IEnumerable<DailyDTO>> GetAllDailiesAsync();
        Task<IEnumerable<DailyDTO>> GetAllDailiesByUserAsync(string userId);
        
        Task<DailyDTO> GetDailyByIdAsync(int dailyId);
        Task<DailyDTO> GetDailyByMoodIdAsync(int moodId);

        Task<IEnumerable<DailyDTO>> GetAllDailiesByMoodIdAsync(int moodId);
        Task CreateDailyAsync(DailyDTO daily);
        Task UpdateDailyAsync(DailyDTO daily);
        Task DeleteDailyByIdAsync(int dailyId);
        



    }
}
