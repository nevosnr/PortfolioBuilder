using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using MudBlazor;
using static Microsoft.AspNetCore.Components.Web.RenderMode;

namespace PortfolioBuilder.Components
{
    public partial class App
    {
        [CascadingParameter]
        private HttpContext HttpContext { get; set; } = default!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;
        private IComponentRenderMode? PageRenderMode =>
            HttpContext.AcceptsInteractiveRouting() && !NavigationManager.Uri.Contains("/Account") ? InteractiveServer : null;
    }
}