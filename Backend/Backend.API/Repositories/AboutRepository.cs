using Backend.API.Entities;
using Backend.API.Entities.Interface;

namespace Backend.API.Repositories;

public class AboutRepository : IRepository<AboutEntity,AboutDTO>
{
    public Task<IEnumerable<AboutDTO>> Get(bool includeded = true)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AboutDTO>> QueryGet(Func<AboutEntity, bool> expresion, bool included = true)
    {
        throw new NotImplementedException();
    }

    public Task<AboutDTO> Create(AboutDTO createDto)
    {
        throw new NotImplementedException();
    }

    public Task<AboutDTO> Update(AboutDTO updateDto)
    {
        throw new NotImplementedException();
    }

    public Task<AboutDTO> Delete(int id)
    {
        throw new NotImplementedException();
    }
}