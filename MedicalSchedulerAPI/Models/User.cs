namespace MedicalSchedulerAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string? DisplayName { get; set; }
        public string? GoogleId { get; set; }
        public string? PasswordHash { get; set; }
        public bool IsPasswordSet { get; set; } = false;
    }
}
