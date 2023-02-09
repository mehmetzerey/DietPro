namespace Diet.Domain.Models.PersonalAggregate;

public class DietRecommendations
{
    public int Id { get; set; }
    public string RecommendationType { get; set; } = string.Empty; 
    public string RecommendationDescription { get; set; } = string.Empty;
    public string RecommendationInstructions { get; set; } = string.Empty;
    public int DietitianPatientMeetingId { get; set; }
}

