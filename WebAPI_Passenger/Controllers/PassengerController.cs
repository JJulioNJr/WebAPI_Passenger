using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Serializers;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebAPI_Passenger.Models;
using WebAPI_Passenger.Services;
using WebAPI_Passenger.Util;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace WebAPI_Passenger.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase {

        private readonly PassengerServices _passengerService;
        private readonly PassengerServices _removeService;
        private readonly PassengerServices _restrictService;
        private readonly AddressServices   _addressService;
       
        public PassengerController(PassengerServices passengerService, PassengerServices removeService, 
                                   PassengerServices restrictService,AddressServices addressService) {

            _passengerService = passengerService;
            _removeService = removeService;
            _restrictService = restrictService;
            _addressService = addressService;
           
        }

        [HttpGet]
        public ActionResult<List<Passenger>> Get() => _passengerService.Get();

        [HttpGet("Cpf", Name = "GetPassenger")]
        public ActionResult<Passenger> GetPassenger(string cpf) {
            var passenger = _passengerService.GetPassenger(cpf);
            if (passenger == null) {
                return NotFound();
            } else {
                return Ok(passenger);
            }
        }

        [HttpPost]
        public  async ActionResult<Passenger> Create(PassengerDTO passengerDTO) {
            PassengerUtil ps = new();
           
            if (ps.ValidateCpf(passengerDTO.Cpf) == true) {
              
                    var passengerIn = _passengerService.GetPassenger(passengerDTO.Cpf);

                // if (CreatedAtRoute("GetPassenger", new { cpf = passenger.Cpf.ToString() }, passenger) != null) {
                if (passengerIn == null) {

                    var address = await _addressService.GetAddress(passengerDTO.Address.ZipCode);
                    var addressIn = new Address() {
                        ZipCode = address.ZipCode,
                        Street = address.Street,
                        Number = address.Number,
                        Complement = address.Complement,
                        City = address.City,
                        State = address.State,
                    };


                   
                 
                    _passengerService.Create(passengerDTO);
                    // _passengerService.Update(passenger.Cpf,passenger);
                }
                   
               

                return CreatedAtRoute("GetPassenger", new { cpf = passengerDTO.Cpf.ToString() }, passengerDTO);
            } else {
                return NotFound();
            }
        }

        [HttpPut ]
        public ActionResult<Passenger> Update(string cpf, Passenger passengerIn) {

            var passenger = _passengerService.GetPassenger(cpf);
            if (passenger == null) {
                return NotFound();
            } else {
                _passengerService.Update(cpf, passengerIn);
                passenger = _passengerService.GetPassenger(cpf);
            }
            return NoContent();
        }

        //[HttpDelete]
        //public async Task<ActionResult> DeleteAsync(string cpf) {

        //    var passenger = _passengerService.GetPassenger(cpf);
        //    if (passenger == null) {
        //        return NotFound();
        //    } else {
        //        _removeService.Create(passenger);
        //        _passengerService.Remove(passenger);
        //    }
        //    return NoContent();
        //}

        //[HttpPut ("cpf", Name = "PutPassenger")]
        //public async Task<ActionResult> RestrictPassenger(Passenger passengerIn, string cpf) {

        //    var passenger = _passengerService.GetPassenger(cpf);
        //    if (passenger == null) {
        //        return NotFound();
        //    } else {

        //        if (passenger.Status.Equals("A")) {
        //            _passengerService.Update(passenger.Status, passengerIn);
        //            _restrictService.CreateRestrict(passenger,cpf);
        //        } else {
        //            return NotFound("Cpf já está Cadastrado como Restrito... ");
        //        }
        //    }
        //    return NoContent();
        //}
    }
}
