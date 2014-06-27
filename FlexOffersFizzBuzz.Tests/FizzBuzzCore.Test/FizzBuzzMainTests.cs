using System.Diagnostics;
using FizzBuzzCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FlexOffersFizzBuzz.Tests.FizzBuzzCore.Test
{
    [TestClass]
    public class FizzBuzzMainTests
    {
        [TestMethod]
        public void Run_CollectionOf_ValidObjects()
        {
            // Arrange
            var listOfExpectedResult = new List<FizzBuzzOperationResults>()
            {
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz)
            };

            var testValues = new List<object>()
            {
                new Cake("Chocolate", 100),
                new Cake("Vanilla", 100),
                new Cake("Strawberry", 100),
                new Cake("Shoe", 100),
                new Cake("Mouse", 100)
            };

            // Act
            var listOfActualresults = FizzBuzz.Run(testValues, 10, 9);

            // Assert
            for (int i = 0; i < listOfExpectedResult.Count; i++)
            {
                Assert.AreEqual(listOfExpectedResult[i].RunStatus, listOfActualresults[i].RunStatus);
                Assert.AreEqual(listOfExpectedResult[i].ResultDictionary, listOfActualresults[i].ResultDictionary);
            }
        }

        [TestMethod]
        public void Run_CollectionOf_InValidObjects()
        {
            // Arrange
            var listOfExpectedResult = new List<FizzBuzzOperationResults>()
            {
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType)
            };

            var testValues = new List<object>()
            {
                new Stopwatch(),
                1,
                "Hello there string!",
                FizzBuzzOperationResultCodes.Fizz,
                null
            };

            // Act
            var listOfActualresults = FizzBuzz.Run(testValues, 10, 9);

            // Assert
            for (int i = 0; i < listOfExpectedResult.Count; i++)
            {
                Assert.AreEqual(listOfExpectedResult[i].RunStatus, listOfActualresults[i].RunStatus);
                Assert.AreEqual(listOfExpectedResult[i].ResultDictionary, listOfActualresults[i].ResultDictionary);
            }
        }

        [TestMethod]
        public void Run_EmptyCollection()
        {
            // Arrange
            var listOfExpectedResult = new List<FizzBuzzOperationResults>()
            {
            };

            var testValues = new List<object>()
            {
            };

            // Act
            var listOfActualresults = FizzBuzz.Run(testValues, 10, 9);

            // Assert
            Assert.AreEqual(listOfExpectedResult.Count, listOfActualresults.Count);
        }

        [TestMethod]
        public void Run_CollectionOf_BothValidAndInvalidValues()
        {
            // Arrange
            var listOfExpectedResult = new List<FizzBuzzOperationResults>()
            {
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType)
            };

            var testValues = new List<object>()
            {
                new Cake("Shoe", 100), //0
                new Stopwatch(),
                new Cake("Strawberry", 100), //2
                1,
                new Cake("Chocolate", 100), //4
                "Hello there string!",
                new Cake("Vanilla", 100), //6
                FizzBuzzOperationResultCodes.Fizz,
                new Cake("Mouse", 100), //8
                null
            };

            // Act
            var listOfActualresults = FizzBuzz.Run(testValues, 10, 9);

            // Assert
            for (int i = 0; i < listOfExpectedResult.Count; i++)
            {
                Assert.AreEqual(listOfExpectedResult[i].RunStatus, listOfActualresults[i].RunStatus);
                Assert.AreEqual(listOfExpectedResult[i].ResultDictionary, listOfActualresults[i].ResultDictionary);
            }
        }

        #region Ignoring this test because I don't want NCrunch to continuosly run this performance tests. I'll run this manually.
        [Ignore]
        [TestMethod]
        public void Run_CollectionOf_ValidObjects_ForPerformance_HugeNumber()
        {
            // Arrange
            var listOfExpectedResult = new List<FizzBuzzOperationResults>();

            for (int i = 0; i < 9999999; i++)
            {
                listOfExpectedResult.Add(new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz));
            }

            var testValues = new List<object>();

            for (int i = 0; i < 9999999; i++)
            {
                testValues.Add(new Cake("Chocolate", 100));
            }

            // Act
            var listOfActualresults = FizzBuzz.Run(testValues, 10, 9);

            // Assert
            for (int i = 0; i < listOfExpectedResult.Count; i++)
            {
                Assert.AreEqual(listOfExpectedResult[i].RunStatus, listOfActualresults[i].RunStatus);
                Assert.AreEqual(listOfExpectedResult[i].ResultDictionary, listOfActualresults[i].ResultDictionary);
            }
        }

        [Ignore]
        [TestMethod]
        public void Run_CollectionOf_InValidObjects_ForPerformance_HugeNumber()
        {
            // Arrange
            var listOfExpectedResult = new List<FizzBuzzOperationResults>();

            for (int i = 0; i < 9999999; i++)
            {
                listOfExpectedResult.Add(new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType));
            }

            var testValues = new List<object>();

            for (int i = 0; i < 9999999; i++)
            {
                testValues.Add(new Stopwatch());
            }

            // Act
            var listOfActualresults = FizzBuzz.Run(testValues, 10, 9);

            // Assert
            for (int i = 0; i < listOfExpectedResult.Count; i++)
            {
                Assert.AreEqual(listOfExpectedResult[i].RunStatus, listOfActualresults[i].RunStatus);
                Assert.AreEqual(listOfExpectedResult[i].ResultDictionary, listOfActualresults[i].ResultDictionary);
            }
        }

        [Ignore]
        [TestMethod]
        public void Run_CollectionOf_BothValidAndInvalidValues_ForPerformance_HugeNumber()
        {
            // Arrange
            var listOfExpectedResult = new List<FizzBuzzOperationResults>();

            for (int i = 0; i < 5000000; i++)
            {
                listOfExpectedResult.Add(new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType));
                listOfExpectedResult.Add(new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz));
            }

            var testValues = new List<object>();

            for (int i = 0; i < 5000000; i++)
            {
                testValues.Add(new Stopwatch());
                testValues.Add(new Cake("Strawberry", 100));
            }

            // Act
            var listOfActualresults = FizzBuzz.Run(testValues, 10, 9);

            // Assert
            for (int i = 0; i < listOfExpectedResult.Count; i++)
            {
                Assert.AreEqual(listOfExpectedResult[i].RunStatus, listOfActualresults[i].RunStatus);
                Assert.AreEqual(listOfExpectedResult[i].ResultDictionary, listOfActualresults[i].ResultDictionary);
            }
        }
        #endregion

        [TestMethod]
        public void Run_CollectionOf_BothValidAndInvalidValues_NumbersAre0()
        {
            // Arrange
            var listOfExpectedResult = new List<FizzBuzzOperationResults>()
            {
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.ObjectValueIsZero),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.ObjectValueIsZero),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.ObjectValueIsZero),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.ObjectValueIsZero),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.ObjectValueIsZero),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType)
            };

            var testValues = new List<object>()
            {
                new Cake("Shoe", 100), //0
                new Stopwatch(),
                new Cake("Strawberry", 100), //2
                1,
                new Cake("Chocolate", 100), //4
                "Hello there string!",
                new Cake("Vanilla", 100), //6
                FizzBuzzOperationResultCodes.Fizz,
                new Cake("Mouse", 100), //8
                null
            };

            // Act
            var listOfActualresults = FizzBuzz.Run(testValues, 0, 0);

            // Assert
            for (int i = 0; i < listOfExpectedResult.Count; i++)
            {
                Assert.AreEqual(listOfExpectedResult[i].RunStatus, listOfActualresults[i].RunStatus);
                Assert.AreEqual(listOfExpectedResult[i].ResultDictionary, listOfActualresults[i].ResultDictionary);
            }
        }

        [TestMethod]
        public void Run_CollectionOf_BothValidAndInvalidValues_NumbersAre0_ObjectDividendIs0()
        {
            // Arrange
            var listOfExpectedResult = new List<FizzBuzzOperationResults>()
            {
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.ObjectValueIsZero),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.ObjectValueIsZero),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.ObjectValueIsZero),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.ObjectValueIsZero),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.ObjectValueIsZero),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType)
            };

            var testValues = new List<object>()
            {
                new Cake("Shoe", 00), //0
                new Stopwatch(),
                new Cake("Strawberry", 0), //2
                1,
                new Cake("Chocolate", 00000), //4
                "Hello there string!",
                new Cake("Vanilla", 00000000), //6
                FizzBuzzOperationResultCodes.Fizz,
                new Cake("Mouse", 0000), //8
                null
            };

            // Act
            var listOfActualresults = FizzBuzz.Run(testValues, 0, 0);

            // Assert
            for (int i = 0; i < listOfExpectedResult.Count; i++)
            {
                Assert.AreEqual(listOfExpectedResult[i].RunStatus, listOfActualresults[i].RunStatus);
                Assert.AreEqual(listOfExpectedResult[i].ResultDictionary, listOfActualresults[i].ResultDictionary);
            }
        }

        [TestMethod]
        public void ExecuteFizzBuzz_InvalidDataType()
        {
            // Arrange
            var expectedResult = new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType);
            var unsupportedObjectType = new Stopwatch();

            // Act
            var actualresult = FizzBuzz.ExecuteFizzBuzz(unsupportedObjectType, 5, 10);

            // Assert
            Assert.AreEqual(expectedResult.RunStatus, actualresult.RunStatus);
        }

        [TestMethod]
        public void ExecuteFizzBuzz_ValidDataType_Fizz()
        {
            // Arrange
            var expectedResult = new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz);
            var supportedDateType = new Cake("Chocolate", 10);

            // Act
            var actualresult = FizzBuzz.ExecuteFizzBuzz(supportedDateType, 10, 9);

            // Assert
            Assert.AreEqual(expectedResult.RunStatus, actualresult.RunStatus);
        }

        [TestMethod]
        public void ExecuteFizzBuzz_ValidDataType_Buzz()
        {
            // Arrange
            var expectedResult = new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Buzz);
            var supportedDateType = new Cake("Chocolate", 10);

            // Act
            var actualresult = FizzBuzz.ExecuteFizzBuzz(supportedDateType, 9, 10);

            // Assert
            Assert.AreEqual(expectedResult.RunStatus, actualresult.RunStatus);
        }

        [TestMethod]
        public void ExecuteFizzBuzz_ValidDataType_FizzBuzz_EqualButDivisibleNumbers()
        {
            // Arrange
            var expectedResult = new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.FizzBuzz);
            var supportedDateType = new Cake("Chocolate", 10);

            // Act
            var actualresult = FizzBuzz.ExecuteFizzBuzz(supportedDateType, 10, 10);

            // Assert
            Assert.AreEqual(expectedResult.RunStatus, actualresult.RunStatus);
        }

        [TestMethod]
        public void ExecuteFizzBuzz_ValidDataType_FizzBuzz_DifferentButDivisibleNumbers()
        {
            // Arrange
            var expectedResult = new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.FizzBuzz);
            var supportedDateType = new Cake("Chocolate", 10);

            // Act
            var actualresult = FizzBuzz.ExecuteFizzBuzz(supportedDateType, 5, 10);

            // Assert
            Assert.AreEqual(expectedResult.RunStatus, actualresult.RunStatus);
        }
    }
}
