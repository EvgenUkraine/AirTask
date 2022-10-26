using AirTek.Database.Dtos;
using AirTek.Database.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace AirTek.Database.Services
{
    public class RepositoryJsonService : IRepositoryJsonService {
        private const string FileName = "coding-assigment-orders.json";
        private const int Capacity = 20;
        private readonly IRepositoryTextService repositoryTextService;

        public RepositoryJsonService(IRepositoryTextService repositoryTextService) {
            this.repositoryTextService = repositoryTextService;
        }

        public IEnumerable<OrderDto> GetAll() {
            var filePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/Data/{FileName}";
            var flights = repositoryTextService.GetAll();
            List<OrderDto> items = new List<OrderDto>();

            using (StreamReader reader = new StreamReader(filePath)) {
                string json = reader.ReadToEnd();
                var jTokens = JObject.Parse(json);                

                foreach (var jToken in jTokens) {
                    OrderDto item = new OrderDto();

                    item.Id = GetId(jToken.Key);
                    item.Arrival = jToken.Value.First.First.ToString();

                    items.Add(item);
                }
            }

            var clonnedList = new List<OrderDto>(items);

            foreach (var flight in flights) {
                var selectedOrders = clonnedList
                    .Where(x => x.Arrival == flight.Arrival)
                    .Take(Capacity);

                selectedOrders
                    .ToList()
                    .ForEach(x => {
                        x.Flight = flight;
                    });

                clonnedList = clonnedList
                    .Except(selectedOrders)
                    .ToList();
            }

            return items;
        }

        private int GetId(string idStr) {
            return Convert.ToInt32(Regex.Match(idStr, @"\d+").Value);
        }
    }
}
