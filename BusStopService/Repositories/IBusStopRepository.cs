using System;
using BusStopService.Models;

namespace BusStopService.Repositories
{
    public interface IBusStopRepository
    {
        BusStopDataDTO GetBusStopData(int stopId);
    }
}
