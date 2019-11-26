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
            return new ObjectResult(_repository.categorie.FindByCondition(x => x.CategoryId == id));
        }


        #endregion

        [HttpGet]
        [Route("Category")]
        public IActionResult GetAllCategorie()
        {
            return new ObjectResult(_repository.categorie.GetAll());
        }

        [HttpPut]
        [Route("Category/ModifyCategory")]
        public IActionResult ModifyCategory([FromBody] Categorie cat)
        {
            var c = _repository.categorie.Update(cat);
            return new ObjectResult(c);
        }

        [HttpPost]
        [Route("Category/CreateCategory")]
        public IActionResult CreateCategory([FromBody] Categorie cat)
        {
            var c = _repository.categorie.Create(cat);
            return new ObjectResult(c);
        }

        [HttpDelete]
        [Route("Category/DeleteCategory")]
        public IActionResult DeleteCategory([FromBody] Categorie cat)
        {
            var c = _repository.categorie.Delete(cat);
            return new ObjectResult(c);
        }


        //Services
        [HttpGet]
        [Route("Services")]
        public IActionResult GetAllServices()
        {
            return new ObjectResult(_repository.service.GetAll());
        }

        [HttpGet]
        [Route("ServicesByCategory")]
        public IActionResult GetServiceByCategory(int categoryId)
        {
            return new ObjectResult(_repository.service.FindByCondition(x => x.CategoryId == categoryId));
        }

        [HttpGet]
        [Route("ServicesByProfessional")]
        public IActionResult GetServiceByProfessional(int professionalId)
        {
            var result = _repository.service.ServicesByProfessionnal(professionalId).ToList();

            return new ObjectResult(_repository.service.ServicesByProfessionnal(professionalId).ToList());
        }

        [HttpPut]
        [Route("ModifyServices")]
        public IActionResult ModifyServices([FromBody] Service serv)
        {
            var c = _repository.service.Update(serv);
            return new ObjectResult(c);
        }

        [HttpPost]
        [Route("CreateService")]
        public IActionResult CreateService([FromBody] Service serv)
        {
            var c = _repository.service.Create(serv);
            return new ObjectResult(c);
        }

        [HttpPost]
        [Route("createManyServices")]
        public IActionResult CreateManyServices([FromBody] IEnumerable<Service> serv)
        {
            var c = _repository.service.CreateMany(serv);
            return new ObjectResult(c);
        }

        [HttpDelete]
        [Route("DeleteService")]
        public IActionResult DeleteService([FromBody] Service serv)
        {
            var c = _repository.service.Delete(serv);
            return new ObjectResult(c);
        }

        [HttpDelete]
        [Route("DeleteManyServices")]
        public IActionResult DeleteManyService([FromBody] IEnumerable<Service> serv)
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
            return new ObjectResult(_repository.professional.GetAll());
        }

        [HttpGet]
        [Route("ProfessionalsByService")]
        public IActionResult ProfessionalsByService(int serviceId)
        {
            return new ObjectResult(_repository.professional.ProfessionalByService(serviceId).ToList());
        }

        [HttpPut]
        [Route("ModifyProfessional")]
        public IActionResult ModifyProfessional([FromBody] Professional prof)
        {
            var c = _repository.professional.Update(prof);
            return new ObjectResult(c);
        }

        [HttpPost]
        [Route("CreateProfessional")]
        public IActionResult CreateProfessional([FromBody] Professional prof)
        {
            var c = _repository.professional.Create(prof);
            return new ObjectResult(c);
        }

        [HttpPost]
        [Route("AddServiceToProfessional")]
        public IActionResult AddServiceToProfessional([FromBody] ProfessionalService serprof)
        {

            var c = _repository.ProfessionalServices.Create(serprof);
            return new ObjectResult("ok");
        }


        [HttpDelete]
        [Route("DeleteProfessional")]
        public IActionResult DeleteProfessional([FromBody] Professional prof)
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
        public IActionResult ModifyCustomer([FromBody] Customer client)
        {
            var c = _repository.Customers.Update(client);
            return new ObjectResult(c);
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public IActionResult CreateCustomer([FromBody] Customer client)
        {
            var c = _repository.Customers.Create(client);
            return new ObjectResult(c);
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public IActionResult DeleteProfessional([FromBody] Customer client)
        {
            var c = _repository.Customers.Delete(client);
            return new ObjectResult(c);
        }

        // Statuts

        [HttpGet]
        [Route("Status")]
        public IActionResult GetAllStatus()
        {
            return new ObjectResult(_repository.status.GetAll());
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
        // Invoices

        [HttpGet]
        [Route("Invoices")]
        public IActionResult GetAllInvoices()
        {
            return new ObjectResult(_repository.invoice.GetAll());
        }

        [HttpGet]
        [Route("SelectedInvoice/{id}")]
        public IActionResult SelectedInvoice(int id)
        {
            return new ObjectResult(_repository.invoice.FindByCondition(x => x.InvoiceId == id));
        }
        [HttpPost]
        [Route("CreateInvoice")]
        public IActionResult CreateInvoice([FromBody] Invoice invoice)
        {
            var c = _repository.invoice.Create(invoice);
            return new ObjectResult(c);
        }
        [HttpDelete]
        [Route("DeleteInvoice")]
        public IActionResult DeleteInvoice([FromBody] Invoice invoices)
        {
            var c = _repository.invoice.Delete(invoices);
            return new ObjectResult(c);
        }
        
        //InvoiceLines
        
        [HttpGet]
        [Route("InvoicesLines")]
        public IActionResult GetAllInvoicesLines()
        {
            return new ObjectResult(_repository.invoicelines.GetAll());
        }

        [HttpGet]
        [Route("SelectedInvoiceLine/{id}")]
        public IActionResult SelectedInvoiceLine(int id)
        {
            return new ObjectResult(_repository.invoicelines.FindByCondition(x => x.InvoicelineId == id));
        }
        [HttpPost]
        [Route("CreateInvoiceLine")]
        public IActionResult CreateInvoiceLine([FromBody] InvoiceLine invoiceLine)
        {
            var c = _repository.invoicelines.Create(invoiceLine);
            return new ObjectResult(c);
        }
        [HttpDelete]
        [Route("DeleteInvoiceLine")]
        public IActionResult DeleteInvoiceLine([FromBody] InvoiceLine invoiceline)
        {
            var c = _repository.invoicelines.Delete(invoiceline);
            return new ObjectResult(c);
        }

    }
}
