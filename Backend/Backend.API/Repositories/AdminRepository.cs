using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Extensions.Entities;
using Backend.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Repositories;

public class AdminRepository : IRepository<AdminDTO>
{
    private CvContext _context;

    public AdminRepository(CvContext context)
    {
        _context = context;
    }

    public IEnumerable<AdminDTO> Get(bool included = true) =>
        _context.Admins.Select(a => a.ToDto());

    public async Task<AdminDTO?> GetByIdAsync(int id, bool included = true)
    {
        var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Id == id);
        return admin?.ToDto();
    }

    public async Task<AdminDTO?> CreateAsync(AdminDTO createDto)
    {
        var entity = createDto.ToEntity();
        entity.Id = 0;
        var result = await _context.Admins.AddAsync(entity);
        var saves = await _context.SaveChangesAsync();
        return result.Entity.ToDto();    }

    public async Task<AdminDTO?> UpdateAsync(AdminDTO updateDto)
    {
        //TODO: Check logic, could be improved
        var updateentity = await _context.Admins.FirstOrDefaultAsync(s => s.Id == updateDto.Id);
        if (updateentity == null) return null;

        _context.Entry(updateentity).State = EntityState.Detached;
        _context.Entry(updateDto.ToEntity()).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return updateDto;    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleteEntity = await _context.Admins.FirstOrDefaultAsync(s => s.Id == id);
        if (deleteEntity == null) return false;

        _context.Admins.Remove(deleteEntity);
        await _context.SaveChangesAsync();
        return true;  
    }
}