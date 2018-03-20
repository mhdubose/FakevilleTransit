using System;
using AutoMapper;
using BusStopService.Models;
using BusStopService.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BusStopServiceTests
{
    public class BusStopServiceTests
    {
        BusStopService.Services.BusStopService _sut;
        Mock<IBusStopRepository> _mockRepo;
        Mock<IMapper> _mockMapper;

        public BusStopServiceTests()
        {
            _mockRepo = new Mock<IBusStopRepository>();
            _mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<BusStopService.Services.BusStopService>>();
            _sut = new BusStopService.Services.BusStopService(_mockRepo.Object, _mockMapper.Object, mockLogger.Object);
        }

        [Fact]
        public void ShouldRetrieveBusStopDataAndMapToDetails(){
            var dto = new BusStopDataDTO();
            _mockRepo.Setup(x => x.GetBusStopData(1)).Returns(dto);

            _sut.GetBusStopDetails(1);
            _mockRepo.Verify(x => x.GetBusStopData(1), Times.Once);
            _mockMapper.Verify(x => x.Map<BusStopDetails>(dto), Times.Once);
        }
    }
}
