using HRMS.Entities;

namespace HRMS.DTOs.ResponseDtos
{
    public class StudentAttendanceResponseDtos
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string Student_Id { get; set; }
        public string Name { get; set; }
         public string Date { get; set; }
        public string? InTime { get; set; }
        public string? OutTime { get; set; }
        public string Status { get; set; }
    }
}
