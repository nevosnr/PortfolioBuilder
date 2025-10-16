namespace PortfolioBuilder.Data.DTOs.UKPolAPIDTOs
{
    public record Location
    (
        string longitude,
        string latitude,
        Street street
    );
}
