using Backend.API.AbstractClasses;
using Backend.API.Entities;
using Backend.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : CvControllerTemplate<AboutDTO>
    {
        public AboutController(IRepository<AboutDTO> mainRepository) : base(mainRepository)
        {

        }
    }
}
