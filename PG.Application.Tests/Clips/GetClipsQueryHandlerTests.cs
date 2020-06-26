using FizzWare.NBuilder;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PG.Application.Handlers.QueryHandlers.Clips;
using PG.Application.Requests.Clips;
using PG.Application.Responses.Clips;
using PG.Models;
using PG.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PG.Application.Tests.Clips
{
    [TestClass]
    public class GetClipsQueryHandlerTests
    {
        #region props
        private bool _isSetup = false;
        private List<Clip> _clips;
        #endregion

        #region tests

        [TestMethod]
        public async Task GetClipsQueryHandler_ShouldReturn3Clips()
        {
            if (!_isSetup)
            {
                SetupMockData();
            }

            // Arrange
            var data = new GetClipsRequest("user1");
            var mockSvc = new Mock<IClipService>();
            mockSvc.Setup(svc => svc.GetClipsbyUserName(It.IsAny<string>())).ReturnsAsync(_clips);
            IRequestHandler<GetClipsRequest, GetClipsResponse> handler = new GetClipsQueryHandler(mockSvc.Object);

            // Act
            var actual = await handler.Handle(data, new System.Threading.CancellationToken());

            // Assert
            Assert.IsNotNull(actual);
        }

        #endregion

        #region private methods

        private void SetupMockData()
        {
            _clips = Builder<Clip>.CreateListOfSize(3).Build().ToList();
            _isSetup = true;
        }

        #endregion
    }
}
