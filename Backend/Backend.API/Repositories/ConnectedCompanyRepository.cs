using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Extensions.Entities;
using Backend.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Repositories;

public class ConnectedCompanyRepository : IRepository<ConnectedCompanyDTO>
{
    private CvContext _context;

    public ConnectedCompanyRepository(CvContext context)
    {
        _context = context;
    }

    public IEnumerable<ConnectedCompanyDTO> Get(bool included = true) =>
        _context.ConnectedCompanies.Include(c => c.Work).Select(c => c.ToDto());

    public async Task<ConnectedCompanyDTO?> GetByIdAsync(int id, bool included = true)
    {
        var company = await _context.ConnectedCompanies.Include(c => c.Work).FirstOrDefaultAsync(c => c.Id == id);
        return company?.ToDto();
    }

    public async Task<ConnectedCompanyDTO> CreateAsync(ConnectedCompanyDTO createDto)
    {
        var entity = createDto.ToEntity();
        entity.Id = 0;
        
        var result = await _context.ConnectedCompanies.AddAsync(entity);
        var saves = await _context.SaveChangesAsync();
        return result.Entity.ToDto();    
    }

    public async Task<ConnectedCompanyDTO?> UpdateAsync(ConnectedCompanyDTO updateDto)
    {
        //TODO: Check logic, could be improved
        var updateentity = await _context.ConnectedCompanies.FirstOrDefaultAsync(s => s.Id == updateDto.Id);
        if (updateentity == null) return null;


        _context.Entry(updateentity).State = EntityState.Detached;
        _context.Entry(updateDto.ToEntity()).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return updateDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleteEntity = await _context.ConnectedCompanies.FirstOrDefaultAsync(s => s.Id == id);
        if (deleteEntity == null) return false;
        _context.ConnectedCompanies.Remove(deleteEntity);
        await _context.SaveChangesAsync();
        return true;
    }
}