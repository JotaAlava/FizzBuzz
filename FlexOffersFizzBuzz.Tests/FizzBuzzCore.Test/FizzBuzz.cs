using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzCore;

namespace FlexOffersFizzBuzz.Tests
{
    [TestClass]
    public class FizzBuzz
    {
        [TestMethod]
        public void CakeDivisible_By_1()
        {
            // Arrange
            var testValue = new Cake("chocolate", 5);
            var expectedResult = 5;

            // Act
            var actualResult = FizzBuzzCore.FizzBuzz.Run(testValue, 5, 10);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
