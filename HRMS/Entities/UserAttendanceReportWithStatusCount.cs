using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Entities
{
    public class UserAttendanceReportWithStatusCount
    {
        public List<UserAttendanceResponseDtos> AttendanceDetails { get; set; }
        public List<AttendanceReportDto> StatusCount { get; set; }
    }
}
