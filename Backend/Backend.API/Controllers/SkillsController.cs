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
    public class SkillsController : ControllerBase
    {
        private IRepository<SkillIncludedDTO> _repository;
        
        public SkillsController(IRepository<SkillIncludedDTO> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? id)
        {
            if (id != null)
            {
                var skill =  await _repository.GetById((int)id);
                return skill != null ? Ok(skill) : NotFound($"Entity not found at id {id}");
            }

            var skills = _repository.Get();
            
            return Ok(skills);
        }
    }
}
