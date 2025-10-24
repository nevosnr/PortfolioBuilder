namespace PortfolioBuilder.Components.Pages
{
    public partial class Calendar
    {
        string monthName = "";
        DateTime monthEnd;
        int numBlankColumns = 0;
        int monthsAway = 0;
        int year;
        
        protected override void OnInitialized()
        {
            CreateMonth();
        }

        private void CreateMonth()
        {
            int baseMonth = DateTime.Now.Month;
            int baseYear = DateTime.Now.Year;

            int toalMonths = baseMonth -1 + monthsAway;
            year = baseYear + (toalMonths / 12);
            int normalizedMonth = (toalMonths % 12 +12 )% 12 +1;
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }
            int month = DateTime.Now.Month + monthsAway;

            year += (month -1) /12;
            month = ((month -1) % 12) +1;
        
            DateTime monthStart = new DateTime(year, normalizedMonth, 1);
            monthEnd = monthStart.AddMonths(1).AddDays(-1);
            monthName = monthStart.ToString("MMMM");

            numBlankColumns = (int)monthStart.DayOfWeek;
        }
    }
}