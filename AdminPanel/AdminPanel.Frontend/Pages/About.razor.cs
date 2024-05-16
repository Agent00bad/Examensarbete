using AdminPanel.Frontend.Interfaces;
using Backend.API.Models;
using Microsoft.AspNetCore.Components;

namespace AdminPanel.Frontend.Pages
{
    public partial class About : ComponentBase
    {
        [Inject]
        protected IRepository<AboutModel> _aboutRepo { get; set; }
        //TODO: Optimize state managment and data fetch
        
        List<AboutModel> abouts = new List<AboutModel>();

        protected override async Task OnInitializedAsync()
        {
            abouts = await _aboutRepo.GetAllAsync();
        }
    }
}
