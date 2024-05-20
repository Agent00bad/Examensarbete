using Backend.API.Entities;

namespace Backend.API.DTOs.RelationsIncluded
{
    public class AboutIncludedDTO : AboutDTO
    {
        public ICollection<LanguageDTO>? Languages { get; set; }
        public ICollection<InterestDTO>? Interests { get; set; }
    }
}
