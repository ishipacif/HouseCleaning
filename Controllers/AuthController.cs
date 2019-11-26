using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HouseCleanersApi.Interfaces;
using HouseCleanersApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Customers = HouseCleanersApi.Data.Customer;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using Professionals = HouseCleanersApi.Data.Professional;
using User = HouseCleanersApi.Data.User;

namespace HouseCleanersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly IGeneralRepository _repository;
        private readonly IConfiguration _config;
        
        
        public AuthController( UserManager<User> userManager, IGeneralRepository repository, SignInManager<User>signInManager, IConfiguration config)
        {
           _userManager = userManager ;
           _signInManager = signInManager;
          _config = config;
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
                var res=_repository.professional.Create(model);
                if (!res)
                {
                   await _userManager.DeleteAsync(user);
                    return BadRequest();
                }
               
                return Ok();

            }

            else
            {
                return new ObjectResult(result.Errors);
            }
        }

[HttpPost]
[Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(Customers model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                User user = new User()
                {
                    firstName = model.FirstName,
                    lastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.PhoneNumber,
                };
                var result = await _userManager.CreateAsync(user, model.password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "customers");
                        model.user = user;
                       var res= _repository.Customers.Create(model);
                       if (!res)
                       {
                           await _userManager.DeleteAsync(user);
                           return BadRequest();
                       }
                        return Ok();

                    }
                    else
                    {
                        return new ObjectResult(result.Errors);
                    }
            }
        }


       [HttpPost]
        [Route("LogIn")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.password, true, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
                    
                 // create token
                 var claims = new[]
                 {
                     new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                     new Claim(ClaimTypes.Name, user.Id),
                     new Claim(ClaimTypes.Role, role)
                 };
                     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:key"]));
                                                 var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                                                 var token = new JwtSecurityToken(
                                                     _config["Tokens:Issuer"],
                                                     _config["Tokens:Audience"],
                                                     claims,
                                                     expires: DateTime.Now.AddMinutes(20),
                                                     signingCredentials: creds
                                                     );
                                                 var results = new
                                                 {
                     
                                                     token = new JwtSecurityTokenHandler().WriteToken(token),
                                                     expiration = token.ValidTo
                                                 };
                                                 return Created("", results);
            }
            else
            {
                
                return BadRequest(result);
            }
           
        }
        
       [ HttpGet]
        [Route("Logout")]
       public async Task<IActionResult>Logout()
       {
           await _signInManager.SignOutAsync();
           return Ok();
       }
    }
}