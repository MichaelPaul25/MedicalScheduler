using MedicalschedulerAPI.Models;

namespace MedicalschedulerAPI.Interfaces
{
    public interface IscheduleRepository
    {
        Task<IEnumerable<schedule>> GetAllAsync();
        Task<schedule?> GetByIdAsync(int id);
        Task<schedule> AddAsync(schedule schedule);
        Task<schedule?> UpdateAsync(schedule schedule);
        Task<bool> DeleteAsync(int id);
    }
}
