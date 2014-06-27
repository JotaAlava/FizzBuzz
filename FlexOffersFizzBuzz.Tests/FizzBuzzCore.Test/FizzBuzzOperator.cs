using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzCore;

namespace FlexOffersFizzBuzz.Tests
{
    [TestClass]
    public class FizzBuzzOperator
    {
        [TestMethod]
        public void CakeDivisible_By_1()
        {
            // Arrange
            var sut = new Cake("chocolate", 1);
            var expectedResult = 1;
            var testValue = 1;

            // Act
            var actualResult = sut / testValue;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CakeDivisible_By_3()
        {
            // Arrange
            var sut = new Cake("chocolate", 6);
            var expectedResult = 3;
            var testValue = 2;

            // Act
            var actualResult = sut / testValue;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CakeDivisible_By_0()
        {
            // Arrange
            var sut = new Cake("chocolate", 0);
            var expectedResult = 0;
            var testValue = 2;

            // Act
            var actualResult = sut / testValue;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CakeDivisible_By_1000000()
        {
            // Arrange
            var sut = new Cake("chocolate", 1000000000);
            var expectedResult = 1000;
            var testValue = 1000000;

            // Act
            var actualResult = sut / testValue;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
