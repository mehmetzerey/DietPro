using Diet.Domain.Enums;
using Diet.Domain.Models.DietitianAggregate;

namespace Diet.Domain.Models.PatientAggregate;

public class Patient : BaseEntity, IAggregateRoot
{
    public int PersonId { get; set; }
    public Person Person { get; set; } = new Person();
    public int DietitianId { get; set; }
    public virtual Dietitian Dietitian { get; set; } = new Dietitian();
}
