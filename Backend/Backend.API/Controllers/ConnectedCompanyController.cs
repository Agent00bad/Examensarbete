using Backend.API.AbstractClasses;
using Backend.API.Entities;
using Backend.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConnectedCompanyController : CvControllerTemplate<ConnectedCompanyDTO>
    {
        public ConnectedCompanyController(IRepository<ConnectedCompanyDTO> mainRepository) : base(mainRepository)
        {
        }
    }
}
