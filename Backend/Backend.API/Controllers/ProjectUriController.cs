using Backend.API.AbstractClasses;
using Backend.API.Entities;
using Backend.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectUriController : CvControllerTemplate<PersonalProjectUriDTO>
    {
        public ProjectUriController(IRepository<PersonalProjectUriDTO> mainRepository) : base(mainRepository)
        {
        }
    }
}
