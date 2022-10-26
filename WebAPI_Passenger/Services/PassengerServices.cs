using MongoDB.Driver;
using System.Collections.Generic;
using WebAPI_Passenger.Models;
using WebAPI_Passenger.Reposittorys;

namespace WebAPI_Passenger.Services {
    public class PassengerServices {

        private readonly IMongoCollection<Passenger> _passenger;
        private readonly IMongoCollection<Passenger> _removedPassenger;
        private readonly IMongoCollection<Passenger> _restrictPassenger;
       // private readonly IMongoCollection<Address> _address;

        public PassengerServices(IDatabaseSettings settings) {

            var passenger = new MongoClient(settings.ConnectionString);
            var dbPassanger = passenger.GetDatabase(settings.DatabaseName);
            _passenger = dbPassanger.GetCollection<Passenger>(settings.PassengerCollectionName);

            var remove = new MongoClient(settings.ConnectionString);
            var dbRemoved = remove.GetDatabase(settings.DatabaseName);
            _removedPassenger = dbRemoved.GetCollection<Passenger>(settings.RemovedPassengerCollectionName);

            var restrict = new MongoClient(settings.ConnectionString);
            var dbRestrict = remove.GetDatabase(settings.DatabaseName);
            _restrictPassenger = dbRestrict.GetCollection<Passenger>(settings.RestrictPassengerCollectionName);

        }

        public Passenger Create(PassengerDTO passengerDTO) {
            Passenger passenger = new();
            passenger.Cpf = passengerDTO.Cpf;
            passenger.Name = passengerDTO.Name;
            passenger.Gender = passengerDTO.Gender;
            passenger.Phone = passengerDTO.Phone;
            passenger.DtBirth = passengerDTO.DtBirth;
            passenger.DtRegister = passengerDTO.DtRegister;
            passenger.Status = passengerDTO.Status;
            passenger.Address=passengerDTO.Address;
            _passenger.InsertOne(passenger);
            return passenger;
        }

       
        public List<Passenger> Get() => _passenger.Find<Passenger>(passenger => true).ToList();
        public Passenger GetPassenger(string cpf) => _passenger.Find<Passenger>(passenger => passenger.Cpf == cpf).FirstOrDefault();

        public void Update(string cpf, Passenger passengerIn) {
            _passenger.ReplaceOne(passenger => passenger.Cpf == cpf, passengerIn);
        }

        public void Remove(Passenger passengerIn) => _passenger.DeleteOne(passenger => passenger.Cpf == passengerIn.Cpf);
    }
}
