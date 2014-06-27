using System;
using FlexOffersFizzBuzz.Tests.Controllers.TestHooks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlexOffersFizzBuzz.Tests.Controllers.IntegrationTests
{
    [TestClass]
    public class FizzBuzzServiceIntegrationTests
    {
        [TestMethod]
        public void GetOperations_DbIsEmpty()
        {
            // Arrange
            var sut = TestingFactory.GetFizzBuzzService();

            // Act
            sut.

            // Assert
        }
    }
}
