namespace MedicalSchedulerAPI.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int UserId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string? Shift { get; set; }
        public string? Notes { get; set; }
        public int ScheduleActivityId { get; set; }
    }
}
