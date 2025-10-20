using Microsoft.EntityFrameworkCore;
using PortfolioBuilder.Data;
using PortfolioBuilder.Data.DTOs.CareerDTOs;

namespace PortfolioBuilder.Components.Pages
{
    public partial class About
    {

        private List<CareerRecordDTO> _careerRecordDTOs = new();
        private PortfolioDbContext _ctx = default!;
        private bool _isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            int _maxRetries = 5;
            int _delayMilliseconds = 2000;
            _isLoading = true;

            for (int attempt = 1; attempt <= _maxRetries; attempt++)
            {
                try
                {
                    await using var _ctx = DbContextFactory.CreateDbContext();

                    _careerRecordDTOs = await _ctx.CareerRecords
                        .AsNoTracking()
                        .OrderByDescending(c => c.careerStateDate)
                        .Select(c => new CareerRecordDTO
                        {
                            _Id = c.Id,
                            _careerIcon = c.careerIcon,
                            _careerJobTitle = c.careerJobTitle,
                            _careerRoleTitle = c.careerRoleTitle,
                            _careerShortDescription = c.careerShortDescription,
                            _careerStartDate = c.careerStateDate,
                            _careerEndDate = c.careerEndDate,
                            _careerLongDescription = c.careerLongDescription
                        })
                        .ToListAsync();
                    break;
                }
                catch (Exception ex)
                {
                    if (attempt == _maxRetries)
                    {
                        // Log the exception or show an error message
                        Console.Error.WriteLine($"Failed to load career records after {attempt} attempts: {ex.Message}");
                    }
                    else
                    {
                        // Wait before retrying
                        await Task.Delay(_delayMilliseconds);
                    }
                }
                finally
                {
                    _isLoading = false;
                }
            }
        }
    }
}