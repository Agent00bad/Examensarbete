using Backend.API.AbstractClasses;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : CvControllerTemplate<WorkExperienceIncludedDTO>
    {
        public WorkController(IRepository<WorkExperienceIncludedDTO> mainRepository) : base(mainRepository)
        {
        }
    }
}
