namespace WebAPI_Passenger.Reposittorys {
    public class DatabaseSettings:IDatabaseSettings {

        public string PassengerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
