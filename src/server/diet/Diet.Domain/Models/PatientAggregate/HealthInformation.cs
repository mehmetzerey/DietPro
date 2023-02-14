namespace Diet.Domain.Models.PatientAggregate;

public class HealthInformation : BaseEntity
{
    public double Weight { get; set; }
    public double Height { get; set; }
    public double BMI { get; set; }
    public string Diseases { get; set; } = string.Empty;
    public string Allergies { get; set; } = string.Empty;
    public string Treatments { get; set; } = string.Empty;
    public string DoctorName { get; set; } = string.Empty;
    public string DoctorContact { get; set; } = string.Empty;
    public DateTime LastExaminationDate { get; set; }
    public DateTime LastLabTestDate { get; set; }
    public string OverallHealthAssessment { get; set; } = string.Empty;
    public int PersonalInfoId { get; set; }
    public virtual Person PersonalInfo { get; set; } = new Person();
    public virtual ICollection<LaboratoryTestResults> LaboratoryTestResults { get; set; } = new List<LaboratoryTestResults>();
}

