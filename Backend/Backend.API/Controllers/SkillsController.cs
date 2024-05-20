using Backend.API.AbstractClasses;
using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Entities.Interface;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Interfaces;
using Backend.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : CvControllerTemplate<SkillIncludedDTO>
    {
        public SkillsController(IRepository<SkillIncludedDTO> mainRepository) : base(mainRepository)
        {
        }
    }
}
