using MedicalSchedulerAPI.Interfaces;
using MedicalSchedulerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSchedulerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _repository;

        public ScheduleController(IScheduleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetAll()
        {
            var schedules = await _repository.GetAllAsync();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetById(int id)
        {
            var schedule = await _repository.GetByIdAsync(id);
            if (schedule == null) return NotFound();
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> Create(Schedule schedule)
        {
            var created = await _repository.AddAsync(schedule);
            return CreatedAtAction(nameof(GetById), new { id = created.ScheduleId }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Schedule>> Update(int id, Schedule schedule)
        {
            if (id != schedule.ScheduleId) return BadRequest();

            var updated = await _repository.UpdateAsync(schedule);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
