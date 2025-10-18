using Microsoft.AspNetCore.Components;

namespace PortfolioBuilder.Data.DTOs.CareerDTOs
{
    public record CareerRecordDTO
    {
        public Guid _Id { get; init; }
        public string? _careerIcon { get; init; }
        public string? _careerJobTitle { get; init; }
        public string? _careerRoleTitle { get; init; }
        public string? _careerShortDescription { get; init; }
        public string? _careerLongDescription { get; init; }
        public DateTime _careerStartDate { get; init; }
        public DateTime? _careerEndDate { get; init; }

    };
}