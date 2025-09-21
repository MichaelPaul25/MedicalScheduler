namespace MedicalSchedulerAPI.Models
{
    public class ScheduleActivity
    {
        public int ActivityId { get; set; }
        public int ScheduleId { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; } // create, update, delete
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public DateTime ActionAt { get; set; } = DateTime.UtcNow;
    }
}
