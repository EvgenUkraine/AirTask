using AirTek.Database.Interfaces;
using AirTek.Interfaces;
using System;

namespace AirTek.Services {
    public class PrintTextService : IPrintTextService {
        private readonly IRepositoryTextService repositoryTextService;

        public PrintTextService(IRepositoryTextService repositoryTextService) {
            this.repositoryTextService = repositoryTextService;
        }

        public void Print() {
            var flights = repositoryTextService.GetAll();

            foreach (var flight in flights) {
                
                Console.WriteLine($"Flight: {flight.FlightId}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
            }
        }
    }
}
