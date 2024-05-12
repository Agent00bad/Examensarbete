using Backend.API.Entities;

namespace Backend.API.DTOs.RelationsIncluded
{
    public class AboutIncludedDTO : AboutDTO
    {
        public ICollection<LanguageDTO>? Languages { get; set; }
        public ICollection<InterestDTO>? Interessts { get; set; }
    }
}
