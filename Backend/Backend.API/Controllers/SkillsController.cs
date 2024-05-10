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
                var skill =  await _repository.GetByIdAsync((int)id);
                return skill != null ? Ok(skill) : NotFound($"Entity not found at id {id}");
            }

            var skills = _repository.Get();
            
            return Ok(skills);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SkillIncludedDTO createDto)
        {
            var result = await _repository.CreateAsync(createDto);
            //TODO:Change to created
            if (result != null) return Ok(result);
            return Problem("Couldn't create resource");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SkillIncludedDTO updateDto)
        {
            var result = await _repository.UpdateAsync(updateDto);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var result =  await _repository.DeleteAsync(id);
            return result != null ? Ok(result) : Problem("Couldn't delete");
        }
    }
}
