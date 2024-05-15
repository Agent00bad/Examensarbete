using AdminPanel.Frontend.Interfaces;
using Backend.API.Models;
using Microsoft.AspNetCore.Components;

namespace AdminPanel.Frontend.Components.About
{
    public partial class AboutCard
    {
        [Inject]
        private IRepository<AboutModel> aboutRepo { get; set; }

        [Parameter]
        public required AboutModel About { get; set; }
        
        //TODO: Move this method to parent component and pass into this component
        public void UpdateAbout()
        {
            //For testing
            AboutModel? UpdateAbout = new AboutModel
            {
                FirstName = "Daniel",
                LastName = "Aldén",
                BirthDate = new DateOnly(2000, 03, 23)
            };
            aboutRepo.UpdateAsync(UpdateAbout);
        }
        
    }
}
