using AdminPanel.Frontend.Interfaces;
using Backend.API.Models;
using Microsoft.AspNetCore.Components;

namespace AdminPanel.Frontend.Components.About
{
    public partial class AboutCard : ComponentBase
    {
        [Inject]
        private IRepository<AboutModel> aboutRepo { get; set; }

        [Parameter]
        public required AboutModel About { get; set; }

        public async Task UpdateAbout()
        {

            var updatedAbout = await aboutRepo.UpdateAsync(About);
            if(updatedAbout != null) About = updatedAbout;
            //TODO: add something to happen when it isn't updated correctly
        }
        
    }
}
