using HouseCleanersApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HouseCleanersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalController : ControllerBase
    {
        private readonly IGeneralRepository _repository;

        public ProfessionalController(IGeneralRepository repository)
        {
            _repository = repository;
        }
        
        
    }
}