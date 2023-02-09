using Diet.Domain.Enums;

namespace Diet.Domain.Models.PersonalAggregate;

public class PersonalInfo : BaseEntity, IAggregateRoot
{
    public string UserId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Age { get; set; }
    public Gender Gender { get; set; } = Gender.Man;
    public virtual HealthInformation HealthInformation { get; set; }
}
