using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzCore;

namespace FlexOffersFizzBuzz.Tests
{
    [TestClass]
    public class IsDivisibleTests
    {
        [TestMethod]
        public void IsDivisible_0_DivisbleBy_7()
        {
            // Arrange
            var sut = new Cake("Chocolate", 0);
            var testDivisor = 7;
            var expectedResult = true;

            // Act
            var actualResult = sut.AmDivisibleBy(testDivisor);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsDivisible_1_DivisbleBy_7()
        {
            // Arrange
            var sut = new Cake("Chocolate", 1);
            var testDivisor = 7;
            var expectedResult = false;

            // Act
            var actualResult = sut.AmDivisibleBy(testDivisor);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsDivisible_7_DivisbleBy_1()
        {
            // Arrange
            var sut = new Cake("Chocolate", 7);
            var testDivisor = 1;
            var expectedResult = true;

            // Act
            var actualResult = sut.AmDivisibleBy(testDivisor);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsDivisible_7_DivisbleBy_Negative_1()
        {
            // Arrange
            var sut = new Cake("Chocolate", 7);
            var testDivisor = -1;
            var expectedResult = true;

            // Act
            var actualResult = sut.AmDivisibleBy(testDivisor);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsDivisible_7_DivisbleBy_Negative_2()
        {
            // Arrange
            var sut = new Cake("Chocolate", 7);
            var testDivisor = -2;
            var expectedResult = false;

            // Act
            var actualResult = sut.AmDivisibleBy(testDivisor);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsDivisible_7_DivisbleBy_Negative_14()
        {
            // Arrange
            var sut = new Cake("Chocolate", 7);
            var testDivisor = -2;
            var expectedResult = false;

            // Act
            var actualResult = sut.AmDivisibleBy(testDivisor);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsDivisible_7_DivisbleBy_14()
        {
            // Arrange
            var sut = new Cake("Chocolate", 7);
            var testDivisor = 14;
            var expectedResult = false;

            // Act
            var actualResult = sut.AmDivisibleBy(testDivisor);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsDivisible_14_DivisbleBy_7()
        {
            // Arrange
            var sut = new Cake("Chocolate", 14);
            var testDivisor = 7;
            var expectedResult = true;

            // Act
            var actualResult = sut.AmDivisibleBy(testDivisor);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsDivisible_21_DivisbleBy_7()
        {
            // Arrange
            var sut = new Cake("Chocolate", 21);
            var testDivisor = 7;
            var expectedResult = true;

            // Act
            var actualResult = sut.AmDivisibleBy(testDivisor);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
