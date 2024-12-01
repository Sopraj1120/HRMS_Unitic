namespace HRMS.Entities
{
    public class UserAttendance
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public TimeSpan InTime { get; set; }
        public TimeSpan OutTime { get; set; }
        public AttendanceStatus Status { get; set; }
  

        public Users User { get; set; }
    }
}
