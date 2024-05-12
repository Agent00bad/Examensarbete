using Backend.API.AbstractClasses;
using Backend.API.Entities;
using Backend.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    //TODO: Implement a login admin system, either manually and change the repository and access levels or with auth0 or the like
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : CvControllerTemplate<AdminDTO>
    {
        public AdminController(IRepository<AdminDTO> mainRepository) : base(mainRepository)
        {
        }
    }
}
