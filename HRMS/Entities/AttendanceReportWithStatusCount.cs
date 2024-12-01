using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Entities
{
    public class AttendanceReportWithStatusCount
    {
        public List<StudentAttendanceResponseDtos> AttendanceDetails { get; set; }
        public List<AttendanceReportDto> StatusCount { get; set; }
    }
}
