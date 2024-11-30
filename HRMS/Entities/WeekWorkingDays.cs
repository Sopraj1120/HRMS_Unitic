namespace HRMS.Entities
{
    public class WeekWorkingDays
    {
        public Guid Id { get; set; }
        public Guid WorkingDaysId { get; set; }
        public weekdays Weekday { get; set; }

       
        public WorkingDays WorkingDays { get; set; }
    }
}
