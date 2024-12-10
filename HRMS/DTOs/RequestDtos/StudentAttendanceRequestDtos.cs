using HRMS.Entities;

namespace HRMS.DTOs.RequestDtos
{
    public class StudentAttendanceRequestDtos
    {
        public DateTime Date { get; set; } = DateTime.Now;

        public DateTime? InTime { get; set; } = DateTime.UtcNow.ToLocalTime();

        public DateTime? OutTime { get; set; } = DateTime.UtcNow.ToLocalTime();
        public AttendanceStatus Status { get; set; } = AttendanceStatus.Present;
    }
}
