namespace Diet.Domain.Models.DietitianAggregate;

public class DietitianPatientMeetings : BaseEntity
{
    public DateTime MeetingDate { get; set; }
    public string MeetingPurpose { get; set; }
    public string MeetingNotes { get; set; }
    public int PatientId { get; set; }
    public int DietitianId { get; set; }
}

