using HRMS.Entities;

namespace HRMS.DTOs.RequestDtos
{
    public class UserAttendanceRequestDtos
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public TimeSpan InTime { get; set; }
        public TimeSpan OutTime { get; set; }
        public AttendanceStatus Status { get; set; } = AttendanceStatus.Present;
    }
}
