using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using AutoMapper;
using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using M=HouseCleanersApi.Models;
using D=HouseCleanersApi.Data;
namespace HouseCleanersApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IGeneralRepository _repository;
        private IMapper _mapper;
        public AdminController(IGeneralRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        #region Categorie

        [HttpGet]
        [Route("SelectCategory/{id}")]
        public IActionResult SelectCategory(int id)
        {
            var result = _mapper.Map<M.Category>(_repository.categorie.FindByCondition(x => x.categoryId == id).FirstOrDefault());
            return new ObjectResult(result);
        }

        

        [HttpGet]
        [Route("Category")]
        public IActionResult GetAllCategorie()
        {
            var result = _mapper.Map<List<M.Category>>(_repository.categorie.GetAll());
            return new ObjectResult(result);
        }

        [HttpPut]
        [Route("Category/ModifyCategory")]
        public IActionResult ModifyCategory([FromBody] M.Category cat)
        {
         
            var c = _repository.categorie.Update(_mapper.Map<D.Categorie>(cat));
            return new ObjectResult(c);
        }

        [HttpPost]
        [Route("Category/CreateCategory")]
        public IActionResult CreateCategory([FromBody] M.Category cat)
        {
            var model = _mapper.Map<D.Categorie>(cat);
            var c = _repository.categorie.Create(model);
            return new ObjectResult(c);
        }

        [HttpDelete]
        [Route("Category/DeleteCategory")]
        public IActionResult DeleteCategory([FromBody] M.Category cat)
        {
            var model = _mapper.Map<D.Categorie>(cat);
            var c = _repository.categorie.Delete(model);
            return new ObjectResult(c);
        }
        #endregion

        #region Services

        //Services
        [HttpGet]
        [Route("Services")]
        public IActionResult GetAllServices()
        {
            var services = _mapper.Map<IEnumerable<M.Service>>(_repository.service.GetAll());
            return new ObjectResult(services);
        }
        [HttpGet]
        [Route("Services/{id}")]
        public IActionResult GetOneServices(int id)
        {
            var services = _mapper.Map<IEnumerable<M.Service>>(_repository.service.FindByCondition(s=>s.serviceId==id));
            return new ObjectResult(services);
        }

        
        [HttpGet]
        [Route("ServicesByCategory")]
        public IActionResult GetServiceByCategory(int categoryId)
        {
            var dbresult = _repository.service.FindByCondition(x => x.categoryId == categoryId).FirstOrDefault();
            var result = _mapper.Map<M.Service>(dbresult);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("ServicesByProfessional")]
        public IActionResult GetServiceByProfessional(int professionalId)
        {
            var dbResult = _repository.service.ServicesByProfessionnal(professionalId).ToList();
            var result = _mapper.Map<IEnumerable<M.Service>>(dbResult);

            return new ObjectResult(result);
        }

        [HttpPut]
        [Route("ModifyServices")]
        public IActionResult ModifyServices([FromBody] M.ServiceCreateUpdateModes serv)
        {
            if (_repository.service.FindByCondition(s=>s.serviceId==serv.serviceId)==null)
            {
                return NotFound();
            }
            
            var toDb = _mapper.Map<D.Service>(serv);
            var c = _repository.service.Update(toDb);
            return new ObjectResult(c);
        }

        [HttpPost]
        [Route("CreateService")]
        public IActionResult CreateService([FromBody] M.ServiceCreateUpdateModes serv)
        {
            var toDb = _mapper.Map<D.Service>(serv);
            var c = _repository.service.Create(toDb);
            return new ObjectResult(c);
        }

        [HttpPost]
        [Route("createManyServices")]
        public IActionResult CreateManyServices([FromBody] IEnumerable<M.ServiceCreateUpdateModes> serv)
        {
            
            var toDb = _mapper.Map<List<D.Service>>(serv);
            var c = _repository.service.CreateMany(toDb);
            return new ObjectResult(c);
        }

        [HttpDelete]
        [Route("DeleteService")]
        public IActionResult DeleteService([FromBody] M.Service serv)
        {
            var toDb = _mapper.Map<D.Service>(serv);
            var c = _repository.service.Delete(toDb);
            return new ObjectResult(c);
        }

        [HttpDelete]
        [Route("DeleteManyServices")]
        public IActionResult DeleteManyService([FromBody] IEnumerable<M.Service> serv)
        {
            var toDb = _mapper.Map<List<D.Service>>(serv);
            var c = _repository.service.DeleteMany(toDb);
            return new ObjectResult(c);
        }
#endregion 
        //[HttpGet("{id}/account")]

        #region professional

        
        // Professionals 

        [HttpGet]
        [Route("Professionals")]
        public IActionResult GetAllProfessionals()
        {
            return new ObjectResult(_mapper.Map<IEnumerable<M.Professional>>(_repository.professional.GetAll()));
        }

        [HttpGet]
        [Route("ProfessionalsByService")]
        public IActionResult ProfessionalsByService(int serviceId)
        {
            return new ObjectResult(_mapper.Map<IEnumerable<M.Professional>>(_repository.professional.ProfessionalByService(serviceId).ToList()));
        }

        [HttpPut]
        [Route("ModifyProfessional")]
        public IActionResult ModifyProfessional([FromBody] M.ProfessionalCreateUpdateModel prof)
        {
            if (_repository.professional.FindByCondition(p=>p.professionalId==prof.professionalId)==null)
            {
                return NotFound();
            }
            var c = _repository.professional.Update(_mapper.Map<D.Professional>(prof));
            return new ObjectResult(c);
        }

        [HttpPost]
        [Route("CreateProfessional")]
        public IActionResult CreateProfessional([FromBody] M.ProfessionalCreateUpdateModel prof)
        {
            var c = _repository.professional.Create(_mapper.Map<D.Professional>(prof));
            return new ObjectResult(c);
        }

        [HttpPost]
        [Route("AddServiceToProfessional")]
        public IActionResult AddServiceToProfessional([FromBody] M.ProfessionalService serprof)
        {
            
            var c = _repository.ProfessionalServices.Create(_mapper.Map<D.ProfessionalService>(serprof));
            return new ObjectResult("ok");
        }


        [HttpDelete]
        [Route("DeleteProfessional")]
        public IActionResult DeleteProfessional([FromBody] M.Professional prof)
        {
            var c = _repository.professional.Delete(_mapper.Map<D.Professional>(prof));
            return new ObjectResult(c);
        }
 #endregion

        #region Customer

 
        // Customer 
        [HttpGet]
        [Route("Customer")]
        public IActionResult GetAllCustomer()
        {
            return new ObjectResult(_repository.Customers.GetAll());
        }

        [HttpPut]
        [Route("ModifyCustomer")]
        public IActionResult ModifyCustomer([FromBody] M.CustomerCreateUpdateModel customer)
        {
           
            if (_repository.Customers.FindByCondition(x=>x.customerId==customer.customerId)==null)
            {
                return NotFound();
            }

            var c = _repository.Customers.Update(_mapper.Map<Customer>((customer)));
            return new ObjectResult(c);
        }

     
        [HttpDelete]
        [Route("DeleteCustomer/id")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer=_repository.Customers.FindById(x=>x.customerId==id);
            if (customer==null)
            {
                return NotFound();
            }

            customer.active = false;
            return new ObjectResult(_repository.Customers.Update(customer));
        }
#endregion

        #region Region status


        // Statuts

        [HttpGet]
        [Route("Status")]
        public IActionResult GetAllStatus()
        {
            return new ObjectResult(_mapper.Map<IEnumerable<M.Status>>(_repository.status.GetAll()));
        }

        [HttpPut]
        [Route("Status/ModifyStatus")]
        public IActionResult ModifyStatus([FromBody] M.StatusCreateUpdateModel myStatus)
        {
            if (_repository.status.FindByCondition(stat=>stat.statusId==myStatus.statusId)==null)
            {
                return NotFound();
            }
            var c = _repository.status.Update(_mapper.Map<D.Status>(myStatus));
            return new ObjectResult(c);
        }

        [HttpPost]
        [Route("Status/CreateStatus")]
        public IActionResult CreateStatus([FromBody] M.Status status)
        {
           var c = _repository.status.Delete(_mapper.Map<D.Status>(status));
            return new ObjectResult(c);
        }

        [HttpDelete]
        [Route("Status/DeleteStatus")]
        public IActionResult DeleteStatus([FromBody] M.Status status)
        {
            var c = _repository.status.Delete(_mapper.Map<D.Status>(status));
            return new ObjectResult(c);
        }
        

        #endregion

        #region Invoices

        

        
        // Invoices

        [HttpGet]
        [Route("Invoices")]
        public IActionResult GetAllInvoices()
        {
            return new ObjectResult(_mapper.Map<IEnumerable<M.Invoice>>(_repository.invoice.GetAll()));
        }

        [HttpGet]
        [Route("SelectedInvoice/{id}")]
        public IActionResult SelectedInvoice(int id)
        {
            return new ObjectResult(_mapper.Map<M.Invoice>(_repository.invoice.FindByCondition(x => x.invoiceId == id).FirstOrDefault()));
        }
        [HttpPost]
        [Route("CreateInvoiceByCustomer")]
        public IActionResult CreateInvoiceByCustomer(int customerid)
        {
            var invoice = new Invoice
            {
                customerId = customerid,
                invoiceAmountTotal = 0,
                invoiceDate = DateTime.Now
            };
           int id= _repository.invoice.Create(invoice).invoiceId;
           var invoiceLines = NoInvoicedLines(customerid) ;

           foreach (var i in invoiceLines)
           {
               i.invoiceId = id;
           }

           _repository.invoicelines.UpdateMany(invoiceLines);
           invoice.invoiceAmountTotal = invoiceLines.Sum(invl => invl.amount);
           _repository.invoice.Update(invoice);
           return new ObjectResult(_repository.invoice.Update(invoice));
        }
        [HttpPost]
        [Route("ModifyInvoice")]
        public IActionResult ModifyInvoice([FromBody] M.InvoiceCreateUpdateModel invoice)
        {
            if (_repository.invoice.FindById(inv=>inv.invoiceId==invoice.invoiceId)==null)
            {
                return NotFound();
            }
            var c = _repository.invoice.Update(_mapper.Map<D.Invoice>(invoice));
            return new ObjectResult(c);
        }
        [HttpDelete]
        [Route("DeleteInvoice")]
        public IActionResult DeleteInvoice([FromBody] M.Invoice invoices)
        {
            var c = _repository.invoice.Delete(_mapper.Map<D.Invoice>(invoices));
            return new ObjectResult(c);
        }
        #endregion
        //InvoiceLines

        #region InvoiceLines

        
        [HttpGet]
        [Route("InvoicesLines")]
        public IActionResult GetAllInvoicesLines()
        {
            return new ObjectResult(_mapper.Map<IEnumerable<M.InvoiceLine>>(_repository.invoicelines.GetAll()));
        }

        [HttpGet]
        [Route("SelectedInvoiceLine/{id}")]
        public IActionResult SelectedInvoiceLine(int id)
        {
            return new ObjectResult(_mapper.Map<IEnumerable<M.InvoiceLine>>(_repository.invoicelines.FindByCondition(x => x.invoicelineId == id).FirstOrDefault()));
        }
        [HttpPost]
        [Route("CreateInvoiceLine")]
        public IActionResult CreateInvoiceLine([FromBody] M.InvoiceCreateUpdateModel invoiceLine)
        {
            var c = _repository.invoicelines.Create(_mapper.Map<InvoiceLine>(invoiceLine));
            return new ObjectResult(c);
        }
        [HttpPut]
        [Route("UpdateInvoiceLine")]
        public IActionResult UpdateInvoiceLine([FromBody] M.InvoiceLineCreateUpdateModel invoiceLine)
        {
            if (_repository.invoicelines.FindByCondition(invl=>invl.invoicelineId==invoiceLine.invoicelineId)==null)
            {
                return NotFound();
            }
            var c = _repository.invoicelines.Update(_mapper.Map<InvoiceLine>(invoiceLine));
            return new ObjectResult(c);
        }
        [HttpPut]
        [Route("UpdateManyInvoiceLine")]
        
        public IActionResult UpdateManyInvoiceLine([FromBody] M.InvoiceLineCreateUpdateModel invoiceLine)
        {
            if (_repository.invoicelines.FindByCondition(invl=>invl.invoicelineId==invoiceLine.invoicelineId)==null)
            {
                return NotFound();
            }
            var c = _repository.invoicelines.UpdateMany(_mapper.Map<List<InvoiceLine>>(invoiceLine));
            return new ObjectResult(c);
        }
        
        [HttpDelete]
        [Route("DeleteInvoiceLine")]
        public IActionResult DeleteInvoiceLine([FromBody] M.InvoiceLine invoiceline)
        {
             var c = _repository.invoicelines.Delete(_mapper.Map<InvoiceLine>(invoiceline));
            return new ObjectResult(c);
        }
        private IEnumerable<InvoiceLine> NoInvoicedLines(int customerid)
        {
            return _repository.invoicelines.GetInvoiceLineByCustomer(customerid).Where(invl=>invl.invoiceId==0);
        }
        #endregion

        #region Reservation

        [HttpGet]
        [Route("Reservations")]
        public IActionResult GetAllReservations()
        {
            return new ObjectResult(_mapper.Map<IEnumerable<M.Reservation>>(_repository.reservation.GetAll()));
        }

        [HttpGet]
        [Route("Reservation/{id}")]
        public IActionResult Reservation(int id)
        {
            return new ObjectResult(_mapper.Map<M.Reservation>(_repository.reservation.FindById(x=>x.reservationId==id)));
        }
        [HttpGet]
        [Route("ReservationByCustomer/{customerid}")]
        public IActionResult ReservationByCustomer(int customerid)
        {
           return new ObjectResult(_mapper.Map<IEnumerable<M.Reservation>>(_repository.reservation.FindByCondition(x => x.customerId == customerid)));
        }
        [HttpGet]
        [Route("ReservationByProfessional/{professionalid}")]
        public IActionResult ReservationByProfessional(int professionalid)
        {
            return new ObjectResult(_mapper.Map<IEnumerable<M.Reservation>>(_repository.reservation.FindByCondition(x => x.professionalId == professionalid)));
        }
        
        #endregion
    }
}
