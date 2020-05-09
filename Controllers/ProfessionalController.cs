using System;
using System.Collections.Generic;
using AutoMapper;
using HouseCleanersApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using M=HouseCleanersApi.Models;
using HouseCleanersApi.Data;
using HouseCleanersApi.Helper;

namespace HouseCleanersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalController : ControllerBase
    {
        private readonly IGeneralRepository _repository;
        private readonly IMapper _mapper;


        public ProfessionalController(IGeneralRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region Infos Professional
        
        [HttpPut]
        [Route("UpdateProfessional")]
        public IActionResult UpdateProfessional([FromBody]M.Professional profesionnal)
        {
            if (_repository.professional.FindById(profesionnal.professionalId)==null)
            {
                return NotFound();
            }

            return new ObjectResult(_repository.professional.Update(_mapper.Map<Professional>(profesionnal)));
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
                    return new ObjectResult(_mapper.Map<M.Reservation>(_repository.reservation.FindById(id)));
                }
                
                //to do ajouter id professionnel (cfr lien associatif .net core) 
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

                [HttpPut]
                [Route("ValidateReservation/{reservationid}")]
                public IActionResult ValidateReservation(int reservationid)
                {
                    var data = _repository.reservation.FindById(reservationid);
                    if (data==null)
                    {
                        return NotFound();
                    }

                    data.statusId = 2;
                    return Ok(_repository.reservation.Update(data));
                }
                
                [HttpPut]
                [Route("RefusedReservation/{reservationid}")]
                public IActionResult RefusedReservation(int reservationid)
                {
                    var data = _repository.reservation.FindById(reservationid);
                    if (data==null)
                    {
                        return NotFound();
                    }

                    data.statusId = 3;
                    return Ok(_repository.reservation.Update(data));
                }

                 [HttpPost]
                 [Route("JobDone/{reservationid}")]
                 public IActionResult JobDone(int reservationid)
                 {
                     var data = _repository.reservation.FindById(reservationid);
                     if (data==null)
                     {
                         return NotFound();
                     }
                     data.statusId = 4;
                     data.Service = _repository.service.FindById((int) data.ServiceId);
                    return new ObjectResult(_repository.invoicelines.Create(InvoiceManagement.GetInvoiceLine(data)));
                    
                 }
                
                 
                #endregion
        
        #region Planning

        [HttpPost]
        [Route("Addplanning")]
        public IActionResult Addplanning([FromBody]M.Planning planning)
        {
            return new ObjectResult(_repository.planning.Create(_mapper.Map<Planning>(planning)));
        }

        public IActionResult GetPlanningProfessionnel(int professionnelid)
        {
            return null;
        }


        public IActionResult GenarateDisponibilities()
        {
            
        }
        
        #endregion
        
        
        

        
                
    }
}