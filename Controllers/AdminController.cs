using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HouseCleanersApi.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class AdminController : ControllerBase
        {
            private readonly IGeneralRepository _repository;

            public AdminController(IGeneralRepository repository)
            {
                _repository = repository;
            }
            
    
            #region Categorie

            [HttpGet]
            [Route("SelectCategory/{id}")]
            public IActionResult SelectCategory(int id)
            {
                return new ObjectResult(_repository.categorie.FindByCondition(x=>x.CategoryId==id));
            }

           
            #endregion
           
            [HttpGet]
            [Route("Category")]
            public IActionResult GetAllCategories()
            {
                return new ObjectResult(_repository.categorie.GetAll());
            }
            
            [HttpPut]
            [Route("Category/ModifyCategory")]
            public IActionResult ModifyCategory([FromBody] Categories cat)
            {
                var c = _repository.categorie.Update(cat);
                return new ObjectResult(c); 
            }
            [HttpPost]
            [Route("Category/CreateCategory")]
            public IActionResult CreateCategory([FromBody] Categories cat)
            {
                var c = _repository.categorie.Create(cat);
                return new ObjectResult(c); 
            }
            [HttpDelete]
            [Route("Category/DeleteCategory")]
            public IActionResult DeleteCategory([FromBody] Categories cat)
            {
                var c = _repository.categorie.Delete(cat);
                return new ObjectResult(c); 
            }
            
            
         //Services
            [HttpGet]
            [Route("Services")]
            public IActionResult GetAllServices()
            {
                return new ObjectResult(_repository.service);
            }
            [HttpPut]
            [Route("ModifyServices")]
            public IActionResult ModifyServices([FromBody] Services serv)
            {
                var c = _repository.service.Update(serv);
                return new ObjectResult(c); 
            }
            [HttpPost]
            [Route("CreateService")]
            public IActionResult CreateService([FromBody] Services serv)
            {
                var c = _repository.service.Create(serv);
                return new ObjectResult(c); 
            }
            [HttpPost]
            [Route("createManyServices")]
            public IActionResult CreateManyServices([FromBody] IEnumerable<Services>serv)
            {
                var c = _repository.service.CreateMany(serv);
                return new ObjectResult(c); 
            }
            [HttpDelete]
            [Route("DeleteService")]
            public IActionResult DeleteService([FromBody] Services serv)
            {
                var c = _repository.service.Delete(serv);
                return new ObjectResult(c); 
            }
            [HttpDelete]
            [Route("DeleteManyServices")]
            public IActionResult DeleteManyService([FromBody] IEnumerable<Services> serv)
            {
                var c = _repository.service.DeleteMany(serv);
                return new ObjectResult(c); 
            }
           
            //[HttpGet("{id}/account")]
            
            // Professionals 
            
            [HttpGet]
            [Route("Professionals")]
            public IActionResult GetAllProfessionals()
            {
                return new ObjectResult(_repository.professional);
            }
            [HttpPut]
            [Route("ModifyProfessional")]
            public IActionResult ModifyProfessional([FromBody] Professionals prof)
            {
                var c = _repository.professional.Update(prof);
                return new ObjectResult(c); 
            }
            [HttpPost]
            [Route("CreateServices")]
            public IActionResult CreateProfessional([FromBody] Professionals prof)
            {
                var c = _repository.professional.Create(prof);
                return new ObjectResult(c); 
            }
          
            [HttpDelete]
            [Route("DeleteProfessional")]
            public IActionResult DeleteProfessional([FromBody] Professionals prof)
            {
                var c = _repository.professional.Delete(prof);
                return new ObjectResult(c); 
            }
            
            // Customer 
            
            [HttpGet]
            [Route("Customer")]
            public IActionResult GetAllCustomer()
            {
                return new ObjectResult(_repository.Customers);
            }
          
            [HttpPut]
            [Route("ModifyCustomer")]
            public IActionResult ModifyCustomer([FromBody] Customers client)
            {
                var c = _repository.Customers.Update(client);
                return new ObjectResult(c); 
            }
            [HttpPost]
            [Route("CreateCustomer")]
            public IActionResult CreateCustomer([FromBody] Customers client)
            {
                var c = _repository.Customers.Create(client);
                return new ObjectResult(c); 
            }
          
            [HttpDelete]
            [Route("DeleteCustomer")]
            public IActionResult DeleteProfessional([FromBody] Customers client)
            {
                var c = _repository.Customers.Delete(client);
                return new ObjectResult(c); 
            }
            
            // Statuts
            
            [HttpGet]
            [Route("Status")]
            public IActionResult GetAllStatus()
            {
                return new ObjectResult(_repository.status);
            }

            [HttpPut]
            [Route("Status/ModifyStatus")]
            public IActionResult ModifyStatus([FromBody] Status status)
            {
                var c = _repository.status.Update(status);
                return new ObjectResult(c); 
            }
            [HttpPost]
            [Route("Status/CreateStatus")]
            public IActionResult CreateStatus([FromBody] Status status)
            {
                var c = _repository.status.Create(status);
                return new ObjectResult(c); 
            }
          
            [HttpDelete]
            [Route("Status/DeleteStatus")]
            public IActionResult DeleteStatus([FromBody] Status status)
            {
                var c = _repository.status.Delete(status);
                return new ObjectResult(c); 
            }
           
        }
}