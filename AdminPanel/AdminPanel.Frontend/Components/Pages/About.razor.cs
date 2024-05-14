using Microsoft.AspNetCore.Components;

namespace AdminPanel.Frontend.Components.Pages
{
    public partial class About : ComponentBase
    {
        [Inject]
        private NavigationManager _nav { get; }
        //TODO: Optimize state managment and data fetch
        protected override async Task OnInitializedAsync()
        {

        }

    }
}
