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
    [Route("/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private SkillRepository _repository;
        
        public SkillController( SkillRepository repository1)
        {
            _repository = repository1;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.Get();
            return Ok(result);
        }
    }
}
