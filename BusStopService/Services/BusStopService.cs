using System;
using AutoMapper;
using BusStopService.Models;
using BusStopService.Repositories;
using Microsoft.Extensions.Logging;

namespace BusStopService.Services
{
    public class BusStopService : IBusStopService
    {
        private readonly IBusStopRepository _busStopRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public BusStopService(IBusStopRepository busStopRepository, IMapper mapper, ILogger<BusStopService> logger)
        {
            _busStopRepository = busStopRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public BusStopDetails GetBusStopDetails(int busStopId)
        {
            _logger.LogDebug("Getting bus stop details for stop {ID}", busStopId);
            return _mapper.Map<BusStopDetails>(_busStopRepository.GetBusStopData(busStopId));
        }
    }
}
