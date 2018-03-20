using System;
using BusStopService.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BusStopServiceTests
{
    public class BusStopRepositoryTests
    {
        BusStopRepository _sut;

        public BusStopRepositoryTests(){
            var mockLogger = new Mock<ILogger<BusStopRepository>>();
            _sut = new BusStopRepository(mockLogger.Object);
        }

        [Fact]
        public void ShouldGenerateBusRouteWithNextTwoTimes(){
            var testTimeSpan = new TimeSpan(7, 59, 0);
            var expectedFirstArrival = new TimeSpan(8, 02, 0);

            var output = _sut.GenerateRoutes(2, testTimeSpan);

            Assert.Equal(3, output.Count);
            Assert.Equal(2, output[0].ArrivalTimes.Count);
            Assert.Equal(expectedFirstArrival, output[0].ArrivalTimes[0]);
        }

        [Fact]
        public void ShouldGenerateTimeSpanFromGivenOffset()
        {
            var inputTimeSpan = new TimeSpan(17, 7, 0);
            var offset = 63;
            var expected = new TimeSpan(18, 3, 0);

            var actual = _sut.TimeSpanFromArrivalTime(inputTimeSpan, offset);

            Assert.Equal(expected, actual);
        }
    }
}
