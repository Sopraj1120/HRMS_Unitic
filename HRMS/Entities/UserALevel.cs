﻿namespace HRMS.Entities
{
    public class UserALevel
    {
        public Guid Id { get; set; }
        public string IndexNo { get; set; }
        public string Year { get; set; }
        public string School { get; set; }
        public string Stream { get; set; }
        public string Subject1 { get; set; }
        public string Subject2 { get; set; }
        public string Subject3 { get; set; }
        public string? GeneralEnglish { get; set; }
        public string? GeneralKnowledge { get; set; }
        public string? GIT { get; set; }
        public Guid userId { get; set; }

        public Users user { get; set; }
    }
}
