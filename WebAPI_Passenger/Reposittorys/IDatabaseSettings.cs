namespace WebAPI_Passenger.Reposittorys {
    public interface IDatabaseSettings {

        string PassengerCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
