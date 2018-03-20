using System;
using AutoMapper;
using BusStopService.Models;

namespace BusStopService.Profiles
{
    public class BusStopDataProfile : Profile
    {
        public BusStopDataProfile()
        {
            CreateMap<BusRouteDTO, BusRoute>();
            CreateMap<BusStopDataDTO, BusStopDetails>();
        }
    }
}
