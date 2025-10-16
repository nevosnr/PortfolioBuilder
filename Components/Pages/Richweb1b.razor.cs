using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PortfolioBuilder.Data.DTOs.UKPolAPIDTOs;
using PortfolioBuilder.Services;

namespace PortfolioBuilder.Components.Pages
{
    public partial class Richweb1b : ComponentBase
    {
        string _selectedForce;
        string _selectedCategory = "all-crime";
        string _selectedNeighbourhood;
        bool _isHydrated = false;
        List<Polforceloc> _policeForces = new();
        List<CrimeCategories> _crimeCategories = new();
        List<Neighbourhood> _neighbourhoods = new();
        List<Latlng> _boundary = new();
        List<CrimeRecord> _crimes = new();
        [Inject] PoliceDataService PoliceDataService { get; set; }
        [Inject] IJSRuntime JS { get; set; }
        private string SelectedForce
        {
            get => _selectedForce;
            set
            {
                if (_selectedForce != value)
                {
                    _selectedForce = value;
                    _ = OnForceChanged(value);
                }
            }
        }

        private string SelectedNeighbourhood
        {
            get => _selectedNeighbourhood;
            set
            {
                if (_selectedNeighbourhood != value)
                {
                    _selectedNeighbourhood = value;
                    _ = OnNeighbourhoodChanged(_selectedForce, value);
                }
            }
        }

        private string SelectedCatNoLoc
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    _ = LoadCrimesWithoutLocation(_selectedForce, value);
                }
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _isHydrated = true;
                StateHasChanged();
            }
        }
        protected override async Task OnInitializedAsync()
        {
            _policeForces = await PoliceDataService.GetForcesAsync();
            _crimeCategories = await PoliceDataService.GetCategoriesAsync();

            if (!string.IsNullOrWhiteSpace(_selectedForce))
            {
                _neighbourhoods = await PoliceDataService.GetNeighbourhoodsAsync(_selectedForce);
                if (!string.IsNullOrWhiteSpace(_selectedNeighbourhood))
                {
                    _boundary = await PoliceDataService.GetBoundryAsync(_selectedForce, _selectedNeighbourhood);
                    await JS.InvokeVoidAsync("drawBoundry", "mapId", _boundary);
                }
            }
        }

        private async Task OnForceChanged(string forceId)
        {
            _crimes.Clear();
            _selectedForce = forceId;
            _neighbourhoods = await PoliceDataService.GetNeighbourhoodsAsync(forceId);
            _selectedNeighbourhood = null;

            await LoadCrimesWithoutLocation(forceId, _selectedCategory);
        }

        private async Task OnNeighbourhoodChanged(string forceId, string nHoodId)
        {
            if (!string.IsNullOrWhiteSpace(nHoodId))
            {
                _boundary = await PoliceDataService.GetBoundryAsync(forceId, nHoodId);
                await JS.InvokeVoidAsync("drawBoundry", "mapId", _boundary);
            }
        }

        private async Task LoadCrimesWithoutLocation(string forceId, string category)
        {
            Console.WriteLine("Firing!");
            if (!string.IsNullOrWhiteSpace(forceId))
            {
                _crimes = await PoliceDataService.GetCrimesNoLocationAsync(forceId.Trim(), category.Trim());
                StateHasChanged();
            }
        }

        [JSInvokable("OnMarkerClick")]
        public static Task OnMarkerClick(string crimeId)
        {
            return Task.CompletedTask;
        }

    }
}