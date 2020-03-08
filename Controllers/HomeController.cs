using AutoMapper;
using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using M= HouseCleanersApi.Models;


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
          [Route("Categories")]
          public IActionResult GetAllCategories()
          {
              return new ObjectResult(_mapper.Map<M.Category>(_repository.categorie.GetAll()));
          }
          

          [HttpGet]
          [Route("Category/id")]
          public IActionResult GetOneCategories(int id)
          {
              return new ObjectResult(_mapper.Map<M.Category>(_repository.categorie.FindByCondition(x=>x.categoryId==id)));
          }

          [HttpGet]
          [Route("Professionals")]
          public IActionResult GetAllProfessionals()
          {
              return  new ObjectResult (_mapper.Map<M.Professional>(_repository.professional.GetAll()));
          }
          [HttpGet]
          [Route("Professional/id")]
          public IActionResult GetOneProfessionals(int id)
          {
              return  new ObjectResult (_mapper.Map<M.Professional>(_repository.professional.FindByCondition(x=>x.professionalId==id)));
          }
          [HttpGet]
          [Route("Professionals/serviceId")]
          public IActionResult GetProfessionalsByService(int serviceId)
          {
              return  new ObjectResult (_mapper.Map<M.Professional>(GetProfessionalsByService(serviceId)));
          }
          [HttpGet]
          [Route("Professionals/postCode")]
          public IActionResult GetProfessionalsAddress(int PostCode)
          {
              return  new ObjectResult (_mapper.Map<M.Professional>(_repository.professional.FindByCondition(x=> x.postCode == PostCode)));
          }
          [HttpGet]
          [Route("Professionals/name")]
          public IActionResult GetProfessionalsAddress(string name)
          {
              return  new ObjectResult (_mapper.Map<M.Professional>(_repository.professional.FindByCondition(x=> x.firstName.Contains(name)||x.lastName.Contains(name))));
          }
          
          
    }
    
}