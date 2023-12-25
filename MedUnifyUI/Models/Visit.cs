namespace MedUnifyUI.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime VisitDate { get; set; }
        public List<ProgressNote> ProgressNotes { get; set; }
    }
}
