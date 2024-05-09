using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Entities.Interface;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        //TODO:for quick test, configure better and remove context
        private CvContext _context;

        public SkillController(SkillRepository repository, CvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //TODO:this is just for testing, configure better
            var repo = new SkillRepository(_context);
            var test = repo.Get();
            return Ok(test);
        }
    }
}
