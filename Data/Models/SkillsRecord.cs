namespace PortfolioBuilder.Data.Models
{
    public class SkillsRecord
    {
        public int Id { get; set; }
        public string? skillTitle { get; set; }
        public string? skillDescription { get; set; }
        public string? skillProvider { get; set; }
        public DateTime? skillDateAchieved { get; set; }

        public Guid? careerRecordId { get; set; }

        public CareerRecord? careerRecord { get; set; }

    }
}
