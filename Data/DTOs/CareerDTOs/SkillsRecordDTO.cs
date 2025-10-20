namespace PortfolioBuilder.Data.DTOs.CareerDTOs
{
    public record SkillsRecordDTO
    (
     int Id,
     string? skillTitle,
     string? skillDescription,
     string? skillProvider,
     DateTime? skillDateAchieved
    );
}
