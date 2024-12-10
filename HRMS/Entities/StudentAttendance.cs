namespace HRMS.Entities
{
    public class StudentAttendance
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string Student_Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime? InTime { get; set; }
        public DateTime? OutTime { get; set; }
        public AttendanceStatus Status { get; set; }


   

        public Students Student { get; set; }
    }

    public enum AttendanceStatus
    {
        absent = 1,
        Present =2,
        LateCome =3,
        
    }
}
