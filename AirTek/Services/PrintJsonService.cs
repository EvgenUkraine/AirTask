using AirTek.Database.Interfaces;
using AirTek.Interfaces;
using System;

namespace AirTek.Services {
    public class PrintJsonService : IPrintJsonService {
        private readonly IRepositoryJsonService repositoryJsonService;
        
        public PrintJsonService(IRepositoryJsonService repositoryJsonService) {
            this.repositoryJsonService = repositoryJsonService;
        }

        public void Print() {
            var orders = repositoryJsonService.GetAll();

            foreach (var order in orders) {
                if(order.Flight != null) {
                    Console.WriteLine($"order: order-{order.Id.ToString().PadLeft(3, '0')}, flightNumber: {order.Flight.FlightId}, departure: {order.Flight.Departure}, arrival: {order.Flight.Arrival}, day: {order.Flight.Day}");
                } else {
                    Console.WriteLine($"order: order-{order.Id.ToString().PadLeft(3, '0')}, flightNumber: not scheduled");
                }
                
            }
        }
    }
}
