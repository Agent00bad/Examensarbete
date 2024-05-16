using Backend.API.Entities.Interface;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.AbstractClasses
{
    public abstract class CvControllerTemplate<TDto> : ControllerBase
        where TDto : IDto
    {
        private IRepository<TDto> _mainRepository;

        public CvControllerTemplate(IRepository<TDto> mainRepository)
        {
            this._mainRepository = mainRepository;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get([FromQuery] int? id)
        {
            if (id != null)
            {
                var dto = await _mainRepository.GetByIdAsync((int)id);
                return dto != null ? Ok(dto) : NotFound($"Entity not found at id {id}");
            }

            var skills = _mainRepository.Get();

            return Ok(skills);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] TDto createDto)
        {
            createDto.Id = 0;

            var result = await _mainRepository.CreateAsync(createDto);

            //TODO:Change to created
            if (result != null) return Ok(result);
            return Problem("Couldn't create resource");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TDto updateDto)
        {
            var result = await _mainRepository.UpdateAsync(updateDto);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        //TODO: Should it reallt be "FromBody"? look into this later
        public virtual async Task<IActionResult> Delete(int id)
        {
            var result = await _mainRepository.DeleteAsync(id);
            return result ? Ok("Succesfully deleted") : Problem("Couldn't delete");
        }
    }
}
