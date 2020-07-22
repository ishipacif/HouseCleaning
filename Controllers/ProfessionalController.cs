using System;
using System.Collections.Generic;
using AutoMapper;
using HouseCleanersApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using M=HouseCleanersApi.Models;
using HouseCleanersApi.Data;
using HouseCleanersApi.Helper;
using System.Linq;

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
        [Route("ModifyProfessional")]
        public IActionResult ModifyProfessional([FromBody] M.ProfessionalCreateUpdateModel prof)
        {
            if (_repository.professional.FindByCondition(p=>p.professionalId==prof.professionalId)==null)
            {
                return NotFound();
            }
            var c = _repository.professional.Update(_mapper.Map<Professional>(prof));
            return new ObjectResult(c);
        }
        [HttpPut]
        [Route("DeleteProfessional")]
        public IActionResult DeleteProfessional(int id)
        {
            var professionel=_repository.professional.FindById(x=>x.professionalId==id);
            if (professionel==null)
            {
                return NotFound();
            }

            professionel.active = false;
            return new ObjectResult(_repository.professional.Update(professionel));
        }

        [HttpPut]
        [Route("ActivateProfessional")]
        public IActionResult ActivateProfessional(int id)
        {
            var professionel = _repository.professional.FindById(x => x.professionalId == id);
            if (professionel == null)
            {
                return NotFound();
            }

            professionel.active = true;
            return new ObjectResult(_repository.professional.Update(professionel));
        }
        #endregion

        #region Reservation

        [HttpGet]
                [Route("Reservations")]
                public IActionResult GetByProfessional(int professionalId)
                {
                    return new ObjectResult(_repository.reservation.GetReservationByProfessional(professionalId));
                }
        
                [HttpGet]
                [Route("Reservation/{id}")]
                public IActionResult Reservation(int id)
                {
                    return new ObjectResult(_mapper.Map<M.Reservation>(_repository.reservation.GetOneReservation(id)));
                }
                
                //* to do ajouter id professionnel (cfr lien associatif .net core) *
                [HttpGet]
                [Route("ReservationByCustomer/{customerid}/{professionalId}")]
                public IActionResult ReservationByCustomer(int customerid,int professinalId)
                {
                    return new ObjectResult(_repository.reservation.GetReservationByCustomer(customerid).Where(x => x.professionalId == professinalId));
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
                    var data = _repository.reservation.FindById(x=>x.reservationId==reservationid);
                    if (data==null)
                    {
                        return NotFound();
                    }

                    data.statusId = 2;
                    return new ObjectResult(_repository.reservation.Update(data));
                }
                
                [HttpPut]
                [Route("RefusedReservation/{reservationid}")]
                public IActionResult RefusedReservation(int reservationid)
                {
                    var data = _repository.reservation.FindById(x=>x.reservationId==reservationid);
                    if (data==null)
                    {
                        return NotFound();
                    }

                    data.statusId = 3;
                    return Ok(_repository.reservation.Update(data));
                }
                 [HttpPut]
                [Route("CancelReservation/{reservationid}")]
                public IActionResult CancelReservation(int reservationid)
                {
                    var data = _repository.reservation.FindById(x => x.reservationId == reservationid);
                    if (data == null)
                    {
                    return NotFound();
                    }

                    data.statusId = 5;
                    return Ok(_repository.reservation.Update(data));
                }

                [HttpPost]
                 [Route("JobDone/{reservationid}")]
                 public IActionResult JobDone(int reservationid)
                 {
                     var myReservation = _repository.reservation.FindById(x=>x.reservationId==reservationid && x.statusId==1);
                     if (myReservation==null)
                     {
                         return NotFound();
                     }
                     myReservation.statusId = 4;
                     myReservation.Service = _repository.service.FindById(x=>x.serviceId==myReservation.ServiceId);
                     _repository.reservation.Update(myReservation);
                    return new ObjectResult(_repository.invoicelines.Create(InvoiceManagement.GetInvoiceLine(myReservation)));
                    
                 }
                
                 
                #endregion
        
        #region Disponibilty

        
         [HttpGet] 
         [Route("GetDisponibilityByProfessionnel")]
        public IActionResult GetPlanningProfessionnel(int professionnelid)
        {
            return new ObjectResult(_repository.Disponibility.FindByCondition(p=>p.professionalId==professionnelid));
        }

        [HttpPost] 
         [Route("GenarateDisponibilities")]
        public IActionResult GenarateDisponibilities([FromBody] M.PlanningProfessional planning)
        {
            var dates = TimeManagement.planningDates(planning.startDate, planning.endDate, planning.saturday,
                planning.sunday);
            var disponibilities =
                TimeManagement.plannningHours(dates, planning.professionalId, planning.startHour, planning.endHour);
            return new ObjectResult(_repository.Disponibility.CreateMany(disponibilities)); 
        }

        [HttpDelete]
        [Route("DeleteOneDisponibility")]
        public IActionResult DeleteOneDisponibility(int id)
        {
            var disponibilty = _repository.Disponibility.FindById(x => x.disponibilityId == id);
            if (disponibilty==null)
            {
                return NotFound();
            }
            return new ObjectResult(_repository.Disponibility.Delete(disponibilty));
        }

        [HttpDelete]
        [Route("DeleteSelectedDisponibility")]
        public IActionResult DeleteSelectedDisponibility(List<int> ids)
        {
            var disponibilties = _repository.Disponibility.FindByCondition(x => ids.Contains(x.disponibilityId)).ToList();
            if (disponibilties == null)
            {
                return NotFound();
            }
            return new ObjectResult(_repository.Disponibility.DeleteMany(disponibilties));
        }
        [HttpDelete]
        [Route("DeleteDisponibilityByDay")]
        public IActionResult DeleteDisponibilityByDay(DateTime date)
        {
            var disponibilties = _repository.Disponibility.FindByCondition(x => x.startHour.Date==date.Date).ToList();
            if (disponibilties == null)
            {
                return NotFound("No disponibilities available");
            }
            return new ObjectResult(_repository.Disponibility.DeleteMany(disponibilties));
        }
        #endregion

        #region Service
        [HttpPost]
        [Route("AddServiceToProfessional")]
        public IActionResult AddServiceToProfessional([FromBody] M.ProfessionalService serprof)
        {
            var c = _repository.ProfessionalServices.Create(_mapper.Map<ProfessionalService>(serprof));
            return new ObjectResult(c);
        }

        [HttpGet]
        [Route("ServicesByProfessional")]
        public IActionResult GetServiceByProfessional(int professionalId)
        {
            var dbResult = _repository.service.ServicesByProfessionnal(professionalId).ToList();
            var result = _mapper.Map<IEnumerable<M.Service>>(dbResult);

            return new ObjectResult(result);
        }
        #endregion

    }
}