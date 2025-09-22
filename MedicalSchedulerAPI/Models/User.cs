namespace MedicalschedulerAPI.Models
{
    public class user
    {
        public int userid { get; set; }
        public string email { get; set; }
        public string? displayname { get; set; }
        public string? googleid { get; set; }
        public string? passwordhash { get; set; }
        public bool ispasswordset { get; set; } = false;
    }
}
