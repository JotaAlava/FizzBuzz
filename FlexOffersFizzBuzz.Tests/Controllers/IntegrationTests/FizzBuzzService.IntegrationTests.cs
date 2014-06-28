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

            // Defaul state of a new FizzBuzzServiceResponse
            var expectedResult = 0;

            // Act
            var actualResults = sut.GetHistoryOfOperations();

            // Assert
            Assert.AreEqual(expectedResult, actualResults.ServiceCallResults.Count);
        }

        [TestMethod]
        public void GetOperations_DbHas_OneRecord_Integer()
        {
            // Arrange
            var sut = TestingFactory.GetFizzBuzzService();
            var typeOfObjectToUse = "1";
            var lowValue = "10";

            var highValue = "20";
            sut.CreateRecordOfOperation(typeOfObjectToUse, lowValue, highValue);

            // Act
            var actualResults = sut.GetHistoryOfOperations();

            // Assert
            Assert.AreEqual(1, actualResults.ServiceCallResults.Count);
            Assert.AreEqual("InvalidType", actualResults.ServiceCallResults[0].Output);
            Assert.AreEqual(int.Parse(highValue), actualResults.ServiceCallResults[0].HighNumber);
            Assert.AreEqual(int.Parse(lowValue), actualResults.ServiceCallResults[0].LowNumber);
        }

        [TestMethod]
        public void GetOperations_DbHas_Cake()
        {
            // Arrange
            var sut = TestingFactory.GetFizzBuzzService();
            var typeOfObjectToUse = "Cake";
            var lowValue = "10";

            var highValue = "20";
            sut.CreateRecordOfOperation(typeOfObjectToUse, lowValue, highValue);

            // Act
            var actualResults = sut.GetHistoryOfOperations();

            // Assert
            Assert.AreEqual(1, actualResults.ServiceCallResults.Count);
            //Assert.AreEqual("InvalidType", actualResults.ServiceCallResults[0].Output);
            //Assert.AreEqual(int.Parse(highValue), actualResults.ServiceCallResults[0].HighNumber);
            //Assert.AreEqual(int.Parse(lowValue), actualResults.ServiceCallResults[0].LowNumber);
        }

        [TestCleanup]
        public void CleanUp()
        {
            DataTestHooks.RollBackDb();
        }
    }
}
