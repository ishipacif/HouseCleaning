using AutoMapper;
using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HouseCleanersApi.Data;
using M=HouseCleanersApi.Models;

namespace HouseCleanersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IGeneralRepository _repository;
        private readonly IMapper _mapper;

        public CustomerController(IGeneralRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("getAllCategory")]
        public IActionResult GetAllCategorie()
        {
            return new ObjectResult(_mapper.Map<M.Category>(_repository.categorie.GetAll()));
        }
        
        [HttpPost]
        [Route("CreateCategory")]
        public IActionResult CreateCategory([FromBody] M.Category cat)
        {
            var c = _repository.categorie.Create(_mapper.Map<Categorie>(cat));
            return new ObjectResult(c); 
        }
    }
}