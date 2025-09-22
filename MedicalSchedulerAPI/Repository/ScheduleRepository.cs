using MedicalschedulerAPI.Data;
using MedicalschedulerAPI.Interfaces;
using MedicalschedulerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalschedulerAPI.Repository
{
    public class scheduleRepository : IscheduleRepository
    {
        private readonly AppDbContext _context;

        public scheduleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<schedule>> GetAllAsync()
        {
            return await _context.schedules.ToListAsync();
        }

        public async Task<schedule?> GetByIdAsync(int id)
        {
            return await _context.schedules.FindAsync(id);
        }

        public async Task<schedule> AddAsync(schedule schedule)
        {
            _context.schedules.Add(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<schedule?> UpdateAsync(schedule schedule)
        {
            var existing = await _context.schedules.FindAsync(schedule.scheduleid);
            if (existing == null) return null;

            existing.scheduledate = schedule.scheduledate;
            existing.shift = schedule.shift;
            existing.notes = schedule.notes;
            existing.userid = schedule.userid;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var schedule = await _context.schedules.FindAsync(id);
            if (schedule == null) return false;

            _context.schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
