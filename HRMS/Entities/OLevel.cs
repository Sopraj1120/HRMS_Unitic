﻿namespace HRMS.Entities
{
    public class OLevel
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string IndexNo { get; set; }
        public string Year { get; set; }
        public string School { get; set; }
        public string Tamil { get; set; }
        public string Science { get; set; }
        public string Maths { get; set; }
        public string Religion { get; set; }
        public string English { get; set; }
        public string History { get; set; }
        public string? Basket1 { get; set; }
        public string? Basket2 { get; set; }
        public string? Basket3 { get; set; }

        public Students Student { get; set; }

    }
}
