using System.Threading.Tasks;
using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HouseCleanersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _role;
        private readonly IGeneralRepository _repository;
        
        
        public AuthController( UserManager<User> userManager, RoleManager<IdentityRole> role, IGeneralRepository repository)
        {
           _userManager = userManager ;
           _role = role;
           _repository = repository; 
        }

        [HttpPost]
        [Route("CreateProfessional")]
        public async Task<IActionResult> CreateProfessional(Professionals model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = new User()
            {
                firstName = model.FirstName,
                lastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, model.password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "professionals");
                model.user = user;
                _repository.professional.Create(model);
                return Ok();

            }

            else
            {
                return new ObjectResult(result.Errors);
            }
        }

/*
        public IActionResult CreateCustomer(Customers model)
        {
            return Ok();
        }*/
    }
}