namespace MedicalschedulerAPI.Models
{
    public class schedule
    {
        public int scheduleid { get; set; }
        public int userid { get; set; }
        public DateTime scheduledate { get; set; }
        public string? shift { get; set; }
        public string? notes { get; set; }
        public int scheduleactivityid { get; set; }
    }
}
