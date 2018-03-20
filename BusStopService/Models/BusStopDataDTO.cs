using System;
using System.Collections.Generic;

namespace BusStopService.Models
{
    public class BusStopDataDTO
    {
        public int Id
        {
            get;
            set;
        }

        public IList<BusRouteDTO> BusRoutes
        {
            get;
            set;
        }
    }
}
