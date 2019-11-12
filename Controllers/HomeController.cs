using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace HouseCleanersApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IGeneralRepository _repository;

        public HomeController(IGeneralRepository repository)
        {
            _repository = repository;
        }
          [HttpGet]
                   [Route("Category")]
                   public IActionResult GetAllCategories()
                   {
                       return new ObjectResult(_repository.categorie);
                   }
    }
    
}