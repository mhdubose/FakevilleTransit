using System;
using System.Collections.Generic;
using BusStopService.Models;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

[assembly: InternalsVisibleTo("BusStopServiceTests")]

namespace BusStopService.Repositories
{
    public class BusStopRepository : IBusStopRepository
    {
        private readonly ILogger _logger;

        public BusStopRepository(ILogger<BusStopRepository> logger){
            _logger = logger;
        }

        public BusStopDataDTO GetBusStopData(int stopId)
        {
            _logger.LogDebug("Generating Mock Data for stop {ID}", stopId);
            return MakeFakeBusStop(stopId);
        }

        internal BusStopDataDTO MakeFakeBusStop(int stopId)
        {
            var currentTime = DateTime.Now.TimeOfDay;
            var busStop = new BusStopDataDTO
            {
                Id = stopId,
                BusRoutes = GenerateRoutes(stopId, currentTime)
            };
            return busStop;
        }

        internal IList<BusRouteDTO> GenerateRoutes(int stopId, TimeSpan currentTime)
        {
            var offset = 2 * (stopId - 1);
            _logger.LogDebug("Bus Stop {ID} base offset is {offset}", stopId, offset);
            var routes = new List<BusRouteDTO>();
            routes.Add(new BusRouteDTO { Id = 1, ArrivalTimes = CreateRouteWithOffset(currentTime, offset) });
            routes.Add(new BusRouteDTO { Id = 2, ArrivalTimes = CreateRouteWithOffset(currentTime, offset + 2) });
            routes.Add(new BusRouteDTO { Id = 3, ArrivalTimes = CreateRouteWithOffset(currentTime, offset + 4) });
            return routes;
        }

        internal IList<TimeSpan> CreateRouteWithOffset(TimeSpan currentTime, int offset)
        {
            var arrivalOne = offset;
            var arrivalTwo = offset + 15;
            var arrivalThree = offset + 30;
            var arrivalFour = offset + 45;
            var arrivalFive = offset + 60;
            var arrivalSix = offset + 75;
            if (currentTime.Minutes < arrivalOne)
            {
                _logger.LogDebug("Using arrival time one and two");
                return new List<TimeSpan>{
                    TimeSpanFromArrivalTime(currentTime, arrivalOne),
                    TimeSpanFromArrivalTime(currentTime, arrivalTwo)
                };
            } else if (currentTime.Minutes < arrivalTwo)
            {
                _logger.LogDebug("Using arrival time two and three");
                return new List<TimeSpan>{
                    TimeSpanFromArrivalTime(currentTime, arrivalTwo),
                    TimeSpanFromArrivalTime(currentTime, arrivalThree)
                };
            } else if (currentTime.Minutes < arrivalThree)
            {
                _logger.LogDebug("Using arrival time three and four");
                return new List<TimeSpan>{
                    TimeSpanFromArrivalTime(currentTime, arrivalThree),
                    TimeSpanFromArrivalTime(currentTime, arrivalFour)
                };
            } else if (currentTime.Minutes < arrivalFour)
            {
                _logger.LogDebug("Using arrival time four and five");
                return new List<TimeSpan>{
                    TimeSpanFromArrivalTime(currentTime, arrivalFour),
                    TimeSpanFromArrivalTime(currentTime, arrivalFive)
                };
            } else 
            {
                _logger.LogDebug("Using arrival time five and six");
                return new List<TimeSpan>{
                    TimeSpanFromArrivalTime(currentTime, arrivalFive),
                    TimeSpanFromArrivalTime(currentTime, arrivalSix)
                };
            }
        }

        internal TimeSpan TimeSpanFromArrivalTime(TimeSpan currentTime, int arrivalTime){
            var hours = arrivalTime / 60;
            var minutes = arrivalTime % 60;
            return new TimeSpan((currentTime.Hours + hours), minutes, 0);
        }
    }
}
