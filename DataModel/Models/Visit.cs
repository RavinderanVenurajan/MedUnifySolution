namespace DataModel.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime VisitDate { get; set; }
      //  public List<ProgressNote>? ProgressNotes { get; set; }
    }
    public class VisitWithProgressNotesDto
    {
        public int PatientId { get; set; }
        public DateTime VisitDate { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal Temperature { get; set; }
        public List<ProgressNoteDto> ProgressNotes { get; set; }
    }
    public class ProgressNoteDto
    {
        public string SectionName { get; set; }
        public string SectionText { get; set; }
    }
}
