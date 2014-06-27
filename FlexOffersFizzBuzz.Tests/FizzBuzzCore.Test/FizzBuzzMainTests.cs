using System.Diagnostics;
using System.Threading;
using FizzBuzzCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlexOffersFizzBuzz.Tests.FizzBuzzCore.Test
{
    [TestClass]
    public class FizzBuzzMainTests
    {
        [TestMethod]
        public void Run_InvalidDataType()
        {
            // Arrange
            var expectedResult = new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType);
            var unsupportedObjectType = new Stopwatch();

            // Act
            var actualresult = FizzBuzz.Run(unsupportedObjectType, 5, 10);

            // Assert
            Assert.AreEqual(expectedResult.RunStatus, actualresult.RunStatus);
        }

        [TestMethod]
        public void Run_ValidDataType_Fizz()
        {
            // Arrange
            var expectedResult = new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz);
            var supportedDateType = new Cake("Chocolate", 10);

            // Act
            var actualresult = FizzBuzz.Run(supportedDateType, 10, 9);

            // Assert
            Assert.AreEqual(expectedResult.RunStatus, actualresult.RunStatus);
        }

        [TestMethod]
        public void Run_ValidDataType_Buzz()
        {
            // Arrange
            var expectedResult = new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Buzz);
            var supportedDateType = new Cake("Chocolate", 10);

            // Act
            var actualresult = FizzBuzz.Run(supportedDateType, 9, 10);

            // Assert
            Assert.AreEqual(expectedResult.RunStatus, actualresult.RunStatus);
        }

        [TestMethod]
        public void Run_ValidDataType_FizzBuzz()
        {
            // Arrange
            var expectedResult = new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.FizzBuzz);
            var supportedDateType = new Cake("Chocolate", 10);

            // Act
            var actualresult = FizzBuzz.Run(supportedDateType, 10, 10);

            // Assert
            Assert.AreEqual(expectedResult.RunStatus, actualresult.RunStatus);
        }
    }
}
