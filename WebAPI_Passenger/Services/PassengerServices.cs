using MongoDB.Driver;
using System.Collections.Generic;
using WebAPI_Passenger.Models;
using WebAPI_Passenger.Reposittorys;

namespace WebAPI_Passenger.Services {
    public class PassengerServices {

        private readonly IMongoCollection<Passenger> _passenger;

        public PassengerServices(IDatabaseSettings settings) {

            var passenger = new MongoClient(settings.ConnectionString);
            var database = passenger.GetDatabase(settings.DatabaseName);
            _passenger = database.GetCollection<Passenger>(settings.PassengerCollectionName);
        }

        public Passenger Create(Passenger passenger) {
            _passenger.InsertOne(passenger);
            return passenger;
        }

        public List<Passenger> Get() => _passenger.Find<Passenger>(passenger => true).ToList();
        public Passenger Get(string cpf) => _passenger.Find<Passenger>(passenger => passenger.Cpf == cpf).FirstOrDefault();

        public void Update(string cpf, Passenger passengerIn) {
            _passenger.ReplaceOne(passenger => passenger.Cpf == cpf, passengerIn);
        }

        public void Remove(Passenger passengerIn) => _passenger.DeleteOne(passenger => passenger.Cpf == passengerIn.Cpf);
    }
}
