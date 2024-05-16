using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Extensions.Entities;
using Backend.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Repositories;

public class InterestRepository : IRepository<InterestDTO>
{
    private CvContext _context;

    public InterestRepository(CvContext context)
    {
        _context = context;
    }

    public IEnumerable<InterestDTO> Get(bool included = true) => _context.Interests.Include(i => i.Person).Select(i => i.ToDto());

    public async Task<InterestDTO?> GetByIdAsync(int id, bool included = true)
    {
        var interest = await _context.Interests.Include(i => i.Person).FirstOrDefaultAsync(i => i.Id == id);
        return interest?.ToDto();
    }

    public async Task<InterestDTO?> CreateAsync(InterestDTO createDto)
    {
        var entity = createDto.ToEntity();
        entity.Id = 0;
        var person = await _context.Abouts.FirstOrDefaultAsync(p => p.Id == entity.Person.Id);
        entity.Person = person;
        var result = await _context.Interests.AddAsync(entity);
        var saves = await _context.SaveChangesAsync();
        return result.Entity.ToDto();
    }

    public async Task<InterestDTO?> UpdateAsync(InterestDTO updateDto)
    {
        //TODO: Check logic, could be improved
        var updateentity = await _context.Interests.FirstOrDefaultAsync(s => s.Id == updateDto.Id);
        if (updateentity == null) return null;


        _context.Entry(updateentity).State = EntityState.Detached;
        _context.Entry(updateDto.ToEntity()).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return updateDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleteEntity = await _context.Interests.FirstOrDefaultAsync(s => s.Id == id);
        if (deleteEntity == null) return false;
        _context.Interests.Remove(deleteEntity);
        await _context.SaveChangesAsync();
        return true;
    }
}