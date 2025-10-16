namespace PortfolioBuilder.Components.Pages
{
    public partial class Recognise
    {
        int calledResult = 0;
        int result = 0;

        private void AddResult()
        {
            result++;
        }

        private void ResetResult()
        {
            result = 0;
            calledResult = 0;
        }

        private int ReturnResult()
        {
            return result;
        }

        private void CallResult()
        {
            calledResult = ReturnResult();
        }
    }
}