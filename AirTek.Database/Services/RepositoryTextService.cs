using AirTek.Database.Dtos;
using AirTek.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AirTek.Database.Services {
    public class RepositoryTextService : IRepositoryTextService {
        private const string FileName = "flights.txt";

        public IEnumerable<FlightDto> GetAll() {
            var filePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/Data/{FileName}";

            int day = 0;
            List<FlightDto> flights = new List<FlightDto>();

            using (var reader = new StreamReader(filePath)) {
                while (!reader.EndOfStream) {
                    var line = reader.ReadLine();

                    if (line.Contains("Day")) {
                        day = GetDay(line);
                    } else {
                        var flight = GetFlightData(line, day);
                        flights.Add(flight);
                    }
                }
            }

            return flights.AsEnumerable();
        }

        private int GetDay(string dayLine) {
            return Convert.ToInt32(Regex.Match(dayLine, @"\d+").Value);
        }

        private FlightDto GetFlightData(string flightLine, int day) {
            var flightLines = Regex.Matches(flightLine, @"\d+|\([A-z]*\)");
            var flight = new FlightDto();

            flight.Day = day;
            flight.FlightId = Convert.ToInt32(flightLines[0].Value);
            flight.Departure = flightLines[1].Value.ToString().Replace("(", "").Replace(")","");
            flight.Arrival = flightLines[2].Value.ToString().Replace("(", "").Replace(")", "");

            return flight;
        }
    }
}
