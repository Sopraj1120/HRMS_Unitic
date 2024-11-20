﻿namespace HRMS.Entities
{
    public class UserExperiance
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public Guid UserId { get; set; }

        public Users User { get; set; }

    }
}
