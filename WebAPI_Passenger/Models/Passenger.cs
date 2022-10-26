
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAPI_Passenger.Util;

namespace WebAPI_Passenger.Models {
    public class Passenger {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        // [DisplayFormat(DataFormatString = "000.000.000-00")]
        [Required(ErrorMessage = "CPF Precisa de 11 Digitos...")]
        [StringLength(14)]
        public string Cpf { get; set; }
        [Required(ErrorMessage ="Nome é Campo Obrigatorio!")]
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(1)]
        public string Gender { get; set; }
        [StringLength(14)]
        public string Phone { get; set; }
       
        public DateTime DtBirth { get; set; }
        public DateTime DtRegister { get; set; }
        [StringLength(1)]
        public string Status { get; set; }
        public Address Address { get; set; }

        public Passenger() { }
        //public Passenger(string cpf,string phone,string status,string gender) {
          

        //    this.Cpf = PassengerUtil.MaskCPF(cpf);
        //    this.Phone = PassengerUtil.MaskPhone(phone);
        //    this.Status=status.ToUpper();
        //    this.Gender=gender.ToUpper();
     

        //    string _register = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
        //    this.DtRegister = DateTime.Parse(_register);
        //   // this.DtBirth=PassengerUtil.MaskDtBirth(birth);
        //    //Address.ZipCode = PassengerUtil.MaskZipCode(this.Address.ZipCode);

        //}
    }
}
