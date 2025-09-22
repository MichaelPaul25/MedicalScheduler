namespace MedicalschedulerAPI.Models
{
    public class scheduleactivity
    {
        public int activityid { get; set; }
        public int scheduleid { get; set; }
        public int userid { get; set; }
        public string action { get; set; } // create, update, delete
        public string? oldvalue { get; set; }
        public string? newvalue { get; set; }
        public DateTime actionat { get; set; } = DateTime.UtcNow;
    }
}
