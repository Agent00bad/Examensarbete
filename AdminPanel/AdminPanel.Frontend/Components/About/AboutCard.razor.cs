using AdminPanel.Frontend.Interfaces;
using Backend.API.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AdminPanel.Frontend.Components.About
{
    public partial class AboutCard : ComponentBase
    {
        [Inject]
        private IRepository<AboutModel> AboutRepo { get; set; }
        
        [Inject]
        private IRepository<LanguageModel> LanguageRepo { get; set; }

        [Inject]
        private IRepository<InterestModel> InterestRepo { get; set; }

        [Parameter]
        public required AboutModel About { get; set; }

        public LanguageModel CreateLanguageModel { get; set; }
        public InterestModel? CreateInterestModel { get; set; }

        protected override void OnInitialized()
        {
            CreateLanguageModel = new LanguageModel {
                Id = 0, 
                Person = About 
            };
            CreateInterestModel = new InterestModel { Id = 0, Person = About, Description = string.Empty };
        }
        public async Task UpdateAbout()
        {

            var updatedAbout = await AboutRepo.UpdateAsync(About);
            if(updatedAbout != null) About = updatedAbout;
            //TODO: add something to happen when it isn't updated correctly
        }
        public async Task CreateLanguage()
        {
            //TODO: Make it possible to add levels
            if(CreateLanguageModel.Name != null || CreateLanguageModel.Name != string.Empty)
            {
                var language = await LanguageRepo.CreateAsync(CreateLanguageModel);
                if(language != null) About.Languages?.Add(language);
            }
            CreateLanguageModel.Name = "";
        }
        public async Task DeleteLanguage(int id)
        {
            var deletedLanguage = await LanguageRepo.DeleteByIdAsync(id);
            if (deletedLanguage != null) About.Languages?.Remove(deletedLanguage);
        }
        public async Task CreateInterest()
        {
            //TODO: Make it possible to add description
            if(CreateInterestModel.Name != string.Empty)
            {
            var interest = await InterestRepo.CreateAsync(CreateInterestModel);
            if (interest != null) About.Interests?.Add(interest);
            CreateInterestModel.Name = "";
            }
        }
        public async Task DeleteInterest(int id)
        {
            var deletedInterest = await InterestRepo.DeleteByIdAsync(id);
            if (deletedInterest != null) About.Interests?.Remove(deletedInterest);
        }
        
    }
}
