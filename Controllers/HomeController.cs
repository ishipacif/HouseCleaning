using AutoMapper;
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
        private readonly IMapper _mapper;

        public HomeController(IGeneralRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
          [HttpGet]
          [Route("Category")]
          public IActionResult GetAllCategories()
          {
              return new ObjectResult(_mapper.Map<Categorie>(_repository.categorie));
          }
    }
    
}