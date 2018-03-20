using System;
using System.Collections.Generic;

namespace BusStopService.Models
{
    public class BusRoute
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
