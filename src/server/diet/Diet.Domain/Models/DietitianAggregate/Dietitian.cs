using Diet.Domain.Models.PatientAggregate;

namespace Diet.Domain.Models.DietitianAggregate;

public class Dietitian : BaseEntity, IAggregateRoot
{
    public string Specialization { get; set; } = string.Empty;
    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
    public int PersonId { get; set; }
    public virtual Person Person { get; set; } = new Person();
}
