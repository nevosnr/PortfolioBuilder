using System.ComponentModel.DataAnnotations;

namespace PortfolioBuilder.Data.Models
{
    public class EventRecord
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string title { get; set; }

        [Required]
        public DateTime startTime { get; set; }

        public DateTime? endTime { get; set; }

        public string? details { get; set; }

    }
}
