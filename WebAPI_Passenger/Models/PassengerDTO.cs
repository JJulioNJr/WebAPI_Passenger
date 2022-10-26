using System.ComponentModel.DataAnnotations;
using System;
using WebAPI_Passenger.Util;

namespace WebAPI_Passenger.Models {
    public class PassengerDTO {

        [Required(ErrorMessage = "CPF Precisa de 11 Digitos...")]
        [StringLength(14)]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Nome é Campo Obrigatorio!")]
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

        public PassengerDTO(string cpf, string phone, string status, string gender) {


            this.Cpf = PassengerUtil.MaskCPF(cpf);
            this.Phone = PassengerUtil.MaskPhone(phone);
            this.Status = status.ToUpper();
            this.Gender = gender.ToUpper();


            string _register = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            this.DtRegister = DateTime.Parse(_register);
            // this.DtBirth=PassengerUtil.MaskDtBirth(birth);
            //Address.ZipCode = PassengerUtil.MaskZipCode(this.Address.ZipCode);

        }
    }
}
