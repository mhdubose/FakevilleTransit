using System;
using System.Collections.Generic;

namespace BusStopService.Models
{
    public class BusStopDetails
    {

        public int Id
        {
            get;
            set;
        }

        public IList<BusRoute> BusRoutes
        {
            get;
            set;
        }

    }
}
