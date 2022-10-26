using System;
using System.Collections.Generic;
using System.Text;

namespace AirTek.Database.Dtos {
    public class OrderDto {
        public OrderDto() {

        }
        public int Id { get; set; }
        public string Arrival { get; set; }
        public FlightDto Flight { get; set; }
    }
}
