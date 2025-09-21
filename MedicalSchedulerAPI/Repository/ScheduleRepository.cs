using MedicalSchedulerAPI.Data;
using MedicalSchedulerAPI.Interfaces;
using MedicalSchedulerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalSchedulerAPI.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AppDbContext _context;

        public ScheduleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Schedule>> GetAllAsync()
        {
            return await _context.Schedules.ToListAsync();
        }

        public async Task<Schedule?> GetByIdAsync(int id)
        {
            return await _context.Schedules.FindAsync(id);
        }

        public async Task<Schedule> AddAsync(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<Schedule?> UpdateAsync(Schedule schedule)
        {
            var existing = await _context.Schedules.FindAsync(schedule.ScheduleId);
            if (existing == null) return null;

            existing.ScheduleDate = schedule.ScheduleDate;
            existing.Shift = schedule.Shift;
            existing.Notes = schedule.Notes;
            existing.UserId = schedule.UserId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null) return false;

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
