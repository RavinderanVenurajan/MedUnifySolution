namespace DataModel.Models
{
    public class ProgressNote
    {
        public int Id { get; set; }
        public int VisitId { get; set; }
        public string SectionName { get; set; }
        public string SectionText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime VisitDate { get;  set; }

    }
}
