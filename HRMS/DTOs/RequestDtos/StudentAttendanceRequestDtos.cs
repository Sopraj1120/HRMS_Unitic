using HRMS.Entities;

namespace HRMS.DTOs.RequestDtos
{
    public class StudentAttendanceRequestDtos
    {
        public DateTime Date { get; set; }= DateTime.Now;
        public AttendanceStatus Status { get; set; } = AttendanceStatus.absent;
    }
}
