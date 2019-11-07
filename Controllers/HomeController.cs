using HouseCleanersApi.Data;
using Microsoft.AspNetCore.Mvc;


namespace HouseCleanersApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly clearnersDbContext _context;

        public HomeController(clearnersDbContext context)
        {
            _context = context;
        }
        // GET
        public IActionResult Index()
        {
            return new ObjectResult(_context.Categories);
        }
[HttpPost]
[Route("CreateCategory")]
        public IActionResult CreateCategory([FromBody] Categories cat)
        {
            var c = _context.Categories.Add(cat);
            _context.SaveChanges();
            return new ObjectResult(c); 
        }
    }
    
}