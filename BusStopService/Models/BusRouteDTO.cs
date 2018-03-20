using System;
using System.Collections.Generic;

namespace BusStopService.Models
{
    public class BusRouteDTO
    {
        public int Id
        {
            get;
            set;
        }

        public IList<TimeSpan> ArrivalTimes
        {
            get;
            set;
        }
    }
}
