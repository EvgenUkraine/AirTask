using System;
using System.Collections.Generic;
using System.Text;

namespace AirTek.Database.Dtos {
    public class FlightDto {
        public FlightDto() {

        }

        public int FlightId { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public int Day { get; set; }
    }
}
