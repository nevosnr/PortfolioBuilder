using Microsoft.AspNetCore.Components;
using PortfolioBuilder.Data.DTOs.CareerDTOs;

namespace PortfolioBuilder.Components
{
    public partial class CareerDialogue
    {
        [Parameter] public CareerRecordDTO careerRecord { get; set; } = default!;
    }
}