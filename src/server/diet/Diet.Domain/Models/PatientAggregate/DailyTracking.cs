using Diet.Domain.Models.DietitianAggregate;

namespace Diet.Domain.Models.PatientAggregate;

public class DailyTracking
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Weight { get; set; }
    public decimal BodyFatPercentage { get; set; }
    public decimal BodyMassIndex { get; set; }
    public decimal WaistCircumference { get; set; }
    public decimal HipCircumference { get; set; }
    public decimal NeckCircumference { get; set; }
    public decimal WaterIntake { get; set; }
    public int SleepDuration { get; set; }
    public string Notes { get; set; } = string.Empty;
    public int PersonId { get; set; }
    public Person Person { get; set; } = new Person();
}
