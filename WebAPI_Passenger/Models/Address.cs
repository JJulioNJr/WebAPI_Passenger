using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonConverterAttribute = Newtonsoft.Json.JsonConverterAttribute;

namespace WebAPI_Passenger.Models {
    public class Address {

        [Required]
        [StringLength(9)]
        [JsonProperty("cep")]
        public string ZipCode { get; set; }

        [StringLength(100)]
        [JsonProperty("logradouro")]
        public string  Street { get; set; }
        
        [StringLength(30)]
        public string Complement { get; set; }
        
        [StringLength(30)]
        [JsonProperty("bairro")]
        public string District { get; set; }
       
        [StringLength(30)]
        [JsonProperty("localidade")]
        public string City { get; set; }
        
        [StringLength(25)]
        [JsonProperty("uf")]
        public string State { get; set; }
        public int Number { get; set; }

       

    }
}
