using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using HouseCleanersApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HouseCleanersApi.Data;
using M=HouseCleanersApi.Models;
using System;
using System.Collections.Generic;

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

        #region reservation
        [HttpGet]
        [Route("GetCustomerReservation")]
        public IActionResult GetCustomerReservation (int customerId)
        {
            var  result =_mapper.Map<List<M.Reservation>>(_repository.reservation.GetReservationByCustomer(customerId).ToList());
            return new ObjectResult(result);
        }
        [HttpGet]
        [Route("GetOneReservation")]
        public IActionResult GetOneReservation(int id)
        {
            return new ObjectResult( _mapper.Map<M.Reservation>(_repository.reservation.GetOneReservation(id)));
        }
        [HttpPost]
        [Route("AddReservation")]
        public IActionResult AddReservation([FromBody] M.ReservationCreateUpdateModel reservation)
        {
            var disponibility = _repository.Disponibility.FindById(x => x.disponibilityId == reservation.disponibilityId);
            var data = _mapper.Map<Reservation>(reservation);
            data.professionalId = disponibility.professionalId;
            data.startHour = disponibility.startHour;
            data.endHour = disponibility.EndHour;
            data.reservationDate = data.startHour.Date;
            
            data.statusId = 1;
            try
            {
                var res=_repository.reservation.Create(data);
                disponibility.reserved = true;
                _repository.Disponibility.Update(disponibility);
                return new ObjectResult(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }
        //[HttpPut]
        //[Route("UpdateReservation")]
        //public IActionResult UpdateReservation( M.ReservationCreateUpdateModel reservation)
        //{
        //    if (_repository.reservation.FindByCondition(res=>res.reservationId==reservation.reservationId)==null)
        //    {
        //        return NotFound();
        //    }
        //    var result= _repository.reservation.Update(_mapper.Map<Reservation>(reservation));
        //    return Ok(result);
        //}
        [HttpPut]
        [Route("CancelReservation")]
        public IActionResult CancelReservation( int reservationId)
        {
            var res = _repository.reservation.FindById(x => x.reservationId == reservationId);
            if (res==null)
            {
                return NotFound();
            }
            res.statusId = 5;
            try
            {
                var result = _repository.reservation.Update(_mapper.Map<Reservation>(res));
                var disponibility= _repository.Disponibility.FindById(x => x.disponibilityId == res.disponibilityId);
                disponibility.reserved = false;
                _repository.Disponibility.Update(disponibility);
                return new ObjectResult(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

           
        }   
        

        #endregion
        
        #region billing
        
        //billing
        [HttpGet]
        [Route("GetInvoices/{customerId}")]
        public IActionResult GetInvoices(int customerId)
        {
            return new ObjectResult(_repository.invoice.GetAll());

        }
        [HttpGet]
        [Route("GetOneInvoices/{id}")]
        public IActionResult GetOneInvoices(int id)
            => new ObjectResult(_repository.invoice.FindByCondition(i=>i.invoiceId==id));


        [HttpPost]
        [Route("CreateInvoice")]
        public IActionResult CreateInvoice([FromBody]M.InvoiceCreateUpdateModel invoice)
        { if (invoice.invoiceLines==null)
            {
                return BadRequest("no invoiceLines");
            }
            
            var model = _mapper.Map<Invoice>(invoice);
           
            int id=  _repository.invoice.CreateInvoice(model); 
            foreach (var i in invoice.invoiceLines)
            {
                i.invoiceId = id;
            }

            model.invoiceAmountTotal = model.invoiceLines.Sum(i => i.amount);

            _repository.invoicelines.CreateMany(model.invoiceLines);
            return new ObjectResult(_mapper.Map<M.Invoice>(model));
        }
        #endregion
        
        #region Infos customer
    [HttpPut] 
    [Route("UpdateInfos")]
    public IActionResult UpdateInfos([FromBody]M.CustomerCreateUpdateModel customer)
        {
            if (_repository.Customers.FindByCondition(res=>res.customerId==customer.customerId)==null)
            {
                return NotFound();
            }
           return new ObjectResult(_repository.Customers.Update(_mapper.Map<Customer>(customer)));
        }


        [HttpPut]
        [Route("DeleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _repository.Customers.FindById(x => x.customerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.active = false;
            return new ObjectResult(_repository.Customers.Update(customer));
        }

        [HttpPut]
        [Route("ActivateCustomer")]
        public IActionResult ActivateCustomer(int id)
        {
            var customer = _repository.Customers.FindById(x => x.customerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.active = true;
            return new ObjectResult(_repository.Customers.Update(customer));
        }
        #endregion
    }
}