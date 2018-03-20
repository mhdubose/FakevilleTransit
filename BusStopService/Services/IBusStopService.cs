using BusStopService.Models;

namespace BusStopService.Services
{
    public interface IBusStopService
    {
        BusStopDetails GetBusStopDetails(int busStopId);
    }
}
