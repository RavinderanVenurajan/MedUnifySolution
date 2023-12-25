﻿namespace MedUnifyApi.Models
{
    public class ProgressNote
    {
        public int Id { get; set; }
        public int VisitId { get; set; }
        public string SectionName { get; set; }
        public string SectionText { get; set; }
        // Add any other properties you need
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime VisitDate { get; internal set; }
    }
}
