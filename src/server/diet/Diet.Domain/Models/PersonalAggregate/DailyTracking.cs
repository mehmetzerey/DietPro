namespace Diet.Domain.Models.PersonalAggregate;

public class DailyTracking
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DietitianId { get; set; }
    public DateTime Date { get; set; }
    public decimal Weight { get; set; }
    public decimal BodyFatPercentage { get; set; }
    public decimal BodyMassIndex { get; set; }
    public decimal WaistCircumference { get; set; }
    public decimal HipCircumference { get; set; }
    public decimal NeckCircumference { get; set; }
    public int WaterIntake { get; set; }
    public int SleepDuration { get; set; }
    public string Notes { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual Dietitian Dietitian { get; set; }
}
