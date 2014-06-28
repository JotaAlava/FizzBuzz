using FizzBuzzCore;
using FlexOffersFizzBuzz.Tests.Controllers.TestHooks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlexOffersFizzBuzz.Tests.FizzBuzzCore.Test
{
    [TestClass]
    public class FizzBuzzOperationResultToStringTests
    {

        [TestMethod]
        public void RepresentationOfResultAsStringMakesSense()
        {
            // Arrange
            var resultOfDivisionWithLow = 10;
            var resultOfDivisionWithHigh = 2;
            var lowValue = 10;
            var highValue = 90;

            var expectedResultDictionary = TestingFactory.GetDictionary();

            // Act
            var sut = new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz, expectedResultDictionary);
            var actualResult = sut.ToString();

            // Assert
        }
    }
}
