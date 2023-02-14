namespace Diet.Domain.Models.PatientAggregate;

public class LaboratoryTestResults : BaseEntity
{
    public string TestName { get; set; } = string.Empty;
    public DateTime TestDate { get; set; }
    public string TestResults { get; set; } = string.Empty;
    public string TestUnits { get; set; } = string.Empty;
    public string TestReferenceRange { get; set; } = string.Empty;
    public string AdditionalNotes { get; set; } = string.Empty;
    public int HealthInformationId { get; set; }
    public virtual HealthInformation HealthInformation { get; set; } = new HealthInformation();
}

