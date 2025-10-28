using System.ComponentModel.DataAnnotations;

namespace PortfolioBuilder.Data.DTOs.CalendarDTOs
{
    public record EventRecordDTO
        (
        Guid Id,
        string title,
        DateTime startTime,
        DateTime? endTime,
        string? details
        );
}
