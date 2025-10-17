namespace PortfolioBuilder.Components.Layout
{
    public partial class MainLayout
    {
        private bool _isDrawerOpen = false;
        private string _snackURL = "https://snack.expo.dev/@nevosnr863/mobile-computing-final";

        public void ToggleDrawer()
        {
            _isDrawerOpen = !_isDrawerOpen;
        }
    }
}