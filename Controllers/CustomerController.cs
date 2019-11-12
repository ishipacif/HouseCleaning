using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HouseCleanersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IGeneralRepository _repository;

        public CustomerController(IGeneralRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("getAllCategory")]
        public IActionResult GetAllCategories()
        {
            return new ObjectResult(_repository.categorie.GetAll());
        }
        
        [HttpPost]
        [Route("CreateCategory")]
        public IActionResult CreateCategory([FromBody] Categories cat)
        {
            var c = _repository.categorie.Create(cat);
            return new ObjectResult(c); 
        }
    }
}