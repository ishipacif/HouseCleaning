using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HouseCleanersApi.Models;
using Microsoft.AspNetCore.Identity;

namespace HouseCleanersApi.Data
{
    public class Seeder
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly clearnersDbContext _context;

        public Seeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, clearnersDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task Seed()
        {
            _context.Database.EnsureCreated();

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole() {Id = "1", Name = "admin"},
                new IdentityRole() {Id = "2", Name = "professionals"},
                new IdentityRole() {Id = "3", Name = "customers"}

            };
            foreach (var item in roles)
            {
                if (await _roleManager.FindByNameAsync(item.Name) == null)
                {
                    await _roleManager.CreateAsync(item);
                }
            }

            var user = await _userManager.FindByEmailAsync("ishipacif@gmail.com");
            if (user == null)
            {
                user = new User()
                {
                    firstName = "Ishimwe",
                    lastName = "Pacifique",
                    UserName = "ishipacif@gmail.com",
                    Email = "ishipacif@gmail.com"

                };
                var result = await _userManager.CreateAsync(user, "Azerty1234=");
                 if (result.Succeeded)
                                {
                                    await _userManager.AddToRoleAsync(user, roles[0].Name);
                                }
                
                                if (result != IdentityResult.Success)
                                {
                                    throw new InvalidOperationException("Failed to create admin");
                                }
            }
            
             
        }
    }
}