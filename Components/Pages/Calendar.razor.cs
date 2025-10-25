namespace PortfolioBuilder.Components.Pages
{
    public partial class Calendar
    {
        string? textValue { get; set; } //placeholder to create form.
        DateTime? dateValue { get; set; } //placeholder to create form.
        string monthName = "";
        DateTime monthEnd;
        int numBlankColumns = 0;
        int monthsAway = 0;
        int year;
        DateTime monthStart;
        
        protected override void OnInitialized()
        {
            CreateMonth();
        }

        private void CreateMonth()
        {
            DateTime baseDate = DateTime.Now.AddMonths(monthsAway);
            year = baseDate.Year;
            int month = baseDate.Month;

            monthStart = new DateTime(year, month, 1);
            monthEnd = monthStart.AddMonths(1).AddDays(-1);
            monthName = monthStart.ToString("MMMM");
            numBlankColumns = (int)monthStart.DayOfWeek;
            
        }

    }
}