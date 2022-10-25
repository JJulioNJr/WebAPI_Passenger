using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using WebAPI_Passenger.Util;

namespace WebAPI_Passenger.Models {
    public class Passenger {


        [Required(ErrorMessage = "CPF Precisa de 11 Digitos...")]
        [StringLength(14)]
        public string Cpf { get; set; }
        [Required(ErrorMessage ="Nome é Campo Obrigatorio!")]
        [StringLength(30)]
        public string Name { get; set; }
        public char? Gender { get; set; }
        [StringLength(14)]
        public string Phone { get; set; }
        public DateTime DtBirth { get; set; }
        public DateTime DtRegister { get; set; }
        public string Status { get; set; }


    }
}
