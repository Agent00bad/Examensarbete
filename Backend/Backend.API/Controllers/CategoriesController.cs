using Backend.API.AbstractClasses;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : CvControllerTemplate<CategoryIncludedDTO>
    {
        public CategoriesController(IRepository<CategoryIncludedDTO> mainRepository) : base(mainRepository)
        {
        }
    }
}
