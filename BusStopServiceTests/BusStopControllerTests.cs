using System;
using BusStopService.Controllers;
using Moq;
using BusStopService.Services;
using Microsoft.Extensions.Logging;
using Xunit;

namespace BusStopServiceTests
{
    public class BusStopControllerTests
    {
        BusStopController _sut;
        Mock<IBusStopService> _mockService;

        public BusStopControllerTests()
        {
            _mockService = new Mock<IBusStopService>();
            var mockLogger = new Mock<ILogger<BusStopController>>();
            _sut = new BusStopController(_mockService.Object, mockLogger.Object);
        }

        [Fact]
        public void ShouldRequestBusStopDetailsFromService(){
            _sut.Get(1);

            _mockService.Verify(x => x.GetBusStopDetails(1), Times.Once);
        }
    }
}
