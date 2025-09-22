using MedicalschedulerAPI.Interfaces;
using MedicalschedulerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalschedulerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class scheduleController : Controller
    {
        private readonly IscheduleRepository _repository;

        public scheduleController(IscheduleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<schedule>>> GetAll()
        {
            var schedules = await _repository.GetAllAsync();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<schedule>> GetById(int id)
        {
            var schedule = await _repository.GetByIdAsync(id);
            if (schedule == null) return NotFound();
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<ActionResult<schedule>> Create(schedule schedule)
        {
            var created = await _repository.AddAsync(schedule);
            return CreatedAtAction(nameof(GetById), new { id = created.scheduleid }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<schedule>> Update(int id, schedule schedule)
        {
            if (id != schedule.scheduleid) return BadRequest();

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

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello from Medical Scheduler API");
        }
    }
}
