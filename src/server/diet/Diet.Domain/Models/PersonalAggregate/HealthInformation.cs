namespace Diet.Domain.Models.PersonalAggregate;

public class HealthInformation : BaseEntity
{
    public double Weight { get; set; }
    public double Height { get; set; }
    public double BMI { get; set; }
    public string Diseases { get; set; }
    public string Allergies { get; set; }
    public string Treatments { get; set; }
    public string DoctorName { get; set; }
    public string DoctorContact { get; set; }
    public DateTime LastExaminationDate { get; set; }
    public DateTime LastLabTestDate { get; set; }
    public string OverallHealthAssessment { get; set; }
    public int PersonalInfoId { get; set; }
    public virtual PersonalInfo PersonalInfo { get; set; }
    public virtual ICollection<LaboratoryTestResults> LaboratoryTestResults { get; set; }
}

