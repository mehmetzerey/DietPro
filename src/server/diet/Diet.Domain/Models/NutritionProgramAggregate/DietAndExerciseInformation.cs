using Diet.Domain.Models.PatientAggregate;

namespace Diet.Domain.Models.NutritionProgramAggregate;

public class DietAndExerciseInformation : BaseEntity
{
    public string CurrentDiet { get; set; } = string.Empty;
    public string CurrentExercisePlan { get; set; } = string.Empty;
    public int DailyCaloricIntake { get; set; }
    public string FoodPreferences { get; set; } = string.Empty;
    public string MealSchedule { get; set; } = string.Empty;
    public int DailyWaterIntake { get; set; }
    public string Supplements { get; set; } = string.Empty;
    public int DailyStepCount { get; set; }
    public string ExerciseFrequency { get; set; } = string.Empty;
    public string ExerciseDuration { get; set; } = string.Empty;
    public string ExerciseIntensity { get; set; } = string.Empty;
    public virtual EatingHabits EatingHabits { get; set; }
}

