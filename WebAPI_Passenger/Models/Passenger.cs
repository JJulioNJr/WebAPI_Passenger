using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using System;
using WebAPI_Passenger.Util;

namespace WebAPI_Passenger.Models {
    public class Passenger {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime LastPurchase { get; set; }
        public DateTime DateRegister { get; set; }
        public string Situation { get; set; }

     
    }
}
