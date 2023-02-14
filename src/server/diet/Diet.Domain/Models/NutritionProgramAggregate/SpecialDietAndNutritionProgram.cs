namespace Diet.Domain.Models.NutritionProgramAggregate;

public class SpecialDietAndNutritionProgram : BaseEntity
{
    public string ProgramName { get; set; } = string.Empty;
    public string ProgramDescription { get; set; } = string.Empty;
    public string ProgramGoals { get; set; } = string.Empty;
    public string ProgramDuration { get; set; } = string.Empty;
    public string ProgramMeals { get; set; } = string.Empty;
    public string ProgramSupplements { get; set; } = string.Empty;
    public string ProgramRestrictions { get; set; } = string.Empty;
    public string ProgramInstructions { get; set; } = string.Empty;
}
