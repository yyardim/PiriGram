using FizzWare.NBuilder;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PG.Application.Handlers.QueryHandlers.Clips;
using PG.Application.Handlers.QueryHandlers.Photos;
using PG.Application.Requests.Clips;
using PG.Application.Requests.Photos;
using PG.Application.Responses.Clips;
using PG.Application.Responses.Photos;
using PG.Models;
using PG.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PG.Application.Tests.Photos
{
    [TestClass]
    public class GetPhotoQueryHandlerTests
    {
        #region props
        private bool _isSetup = false;
        private Photo _photo;
        #endregion

        #region tests

        [TestMethod]
        public async Task GetPhotoQueryHandler_ShouldReturnSinglePhotoGivenId()
        {
            if (!_isSetup)
            {
                SetupMockData();
            }

            // Arrange
            var data = new GetPhotoRequest(new System.Guid());
            var mockSvc = new Mock<IPhotoService>();
            mockSvc.Setup(svc => svc.GetPhotoById(It.IsAny<Guid>())).ReturnsAsync(_photo);
            IRequestHandler<GetPhotoRequest, GetPhotoResponse> handler = new GetPhotoQueryHandler(mockSvc.Object);

            // Act
            var actual = await handler.Handle(data, new System.Threading.CancellationToken());

            // Assert
            Assert.IsNotNull(actual);
        }

        #endregion

        #region private methods

        private void SetupMockData()
        {
            _photo = Builder<Photo>.CreateNew().Build();
            _isSetup = true;
        }

        #endregion
    }
}
