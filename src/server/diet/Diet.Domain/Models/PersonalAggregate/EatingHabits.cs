namespace Diet.Domain.Models.PersonalAggregate;

public class EatingHabits : BaseEntity
{
    public int ServingsOfFruitsPerDay { get; set; }
    public int ServingsOfVegetablesPerDay { get; set; }
    public int ServingsOfProteinPerDay { get; set; }
    public int ServingsOfCarbohydratesPerDay { get; set; }
    public int ServingsOfDairyPerDay { get; set; }
    public int ServingsOfFatPerDay { get; set; }
    public int ServingsOfSnacksPerDay { get; set; }
    public int ServingsOfSugarPerDay { get; set; }
    public int ServingsOfAlcoholPerWeek { get; set; }
    public bool FollowsSpecialDiet { get; set; }
    public string SpecialDiet { get; set; } = string.Empty;
    public int DietAndExerciseInformationId { get; set; }
    public virtual DietAndExerciseInformation DietAndExerciseInformation { get; set; }
}

