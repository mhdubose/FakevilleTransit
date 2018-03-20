using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusStopService.Models;
using BusStopService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BusStopService.Controllers
{
    [Route("api/[controller]")]
    public class BusStopController : ControllerBase
    {
        private readonly IBusStopService _busStopService;
        private readonly ILogger _logger;

        public BusStopController(IBusStopService busStopService, ILogger<BusStopController> logger)
        {
            _busStopService = busStopService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public BusStopDetails Get(int id)
        {
            _logger.LogDebug("Retrieving details for bus stop {ID}", id);
            return _busStopService.GetBusStopDetails(id);
        }
    }
}
