using Backend.API.AbstractClasses;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EducationController : CvControllerTemplate<EducationIncludedDTO>
    {
        public EducationController(IRepository<EducationIncludedDTO> mainRepository) : base(mainRepository)
        {
        }
    }
}
