using System.Diagnostics;
using FizzBuzzCore;
using FlexOffersFizzBuzz.Tests.Controllers.TestHooks;
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
            var expectedResultDictionary = TestingFactory.GetDictionary(10, 90, 2, 10);

            var listOfExpectedResult = new List<FizzBuzzOperationResults>()
            {
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz, expectedResultDictionary),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz, expectedResultDictionary),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz, expectedResultDictionary),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz, expectedResultDictionary),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Fizz, expectedResultDictionary)
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
            var listOfActualresults = FizzBuzz.Run(testValues, 10, 90);

            // Assert
            for (int i = 0; i < listOfExpectedResult.Count; i++)
            {
                Assert.AreEqual(listOfExpectedResult[i].RunStatus, listOfActualresults[i].RunStatus);
                Assert.AreEqual(listOfExpectedResult[i].ResultDictionary.Count, listOfActualresults[i].ResultDictionary.Count);
            }
        }

        [TestMethod]
        public void Run_CollectionOf_InValidObjects()
        {
            // Arrange
            var expectedOperationResult = new FizzBuzzOperationResults();
            expectedOperationResult.RunStatus = FizzBuzzOperationResultCodes.InvalidType;
            expectedOperationResult.ResultDictionary = TestingFactory.GetDictionary(1);

            var listOfExpectedResult = new List<FizzBuzzOperationResults>()
            {
                expectedOperationResult,
                expectedOperationResult,
                expectedOperationResult,
                expectedOperationResult,
                expectedOperationResult
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
            var listOfActualresults = FizzBuzz.Run(testValues, 10, 90);

            // Assert
            for (int i = 0; i < listOfExpectedResult.Count; i++)
            {
                Assert.AreEqual(listOfExpectedResult[i].RunStatus, listOfActualresults[i].RunStatus);
                Assert.AreEqual(listOfExpectedResult[i].ResultDictionary.Count, listOfActualresults[i].ResultDictionary.Count);
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
            var expectedResultDictionary = TestingFactory.GetDictionary(2);
            var expectedResultDictionaryForInvalids = TestingFactory.GetDictionary(1);

            var listOfExpectedResult = new List<FizzBuzzOperationResults>()
            {
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Buzz, expectedResultDictionary),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType, expectedResultDictionaryForInvalids),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Buzz, expectedResultDictionary),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType, expectedResultDictionaryForInvalids),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Buzz, expectedResultDictionary),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType, expectedResultDictionaryForInvalids),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Buzz, expectedResultDictionary),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType, expectedResultDictionaryForInvalids),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.Buzz, expectedResultDictionary),
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType, expectedResultDictionaryForInvalids)
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
            var listOfActualresults = FizzBuzz.Run(testValues, 9, 10);

            // Assert
            for (int i = 0; i < listOfExpectedResult.Count; i++)
            {
                Assert.AreEqual(listOfExpectedResult[i].RunStatus, listOfActualresults[i].RunStatus);
                Assert.AreEqual(listOfExpectedResult[i].ResultDictionary.Count, listOfActualresults[i].ResultDictionary.Count);
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
            var expectedDictionaryOfResults = TestingFactory.GetDictionary(1);
            var expectedOperationResult = new FizzBuzzOperationResults();
            expectedOperationResult.RunStatus = FizzBuzzOperationResultCodes.ObjectValueIsZero;
            expectedOperationResult.ResultDictionary = new Dictionary<DividendQuotientPair, string>();

            var listOfExpectedResult = new List<FizzBuzzOperationResults>()
            {
                expectedOperationResult,
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType, expectedDictionaryOfResults),
                expectedOperationResult,
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType, expectedDictionaryOfResults),
                expectedOperationResult,
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType, expectedDictionaryOfResults),
                expectedOperationResult,
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType, expectedDictionaryOfResults),
                expectedOperationResult,
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType, expectedDictionaryOfResults),
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
                Assert.AreEqual(listOfExpectedResult[i].ResultDictionary.Count, listOfActualresults[i].ResultDictionary.Count);
            }
        }

        [TestMethod]
        public void Run_CollectionOf_BothValidAndInvalidValues_NumbersAre0_ObjectDividendIs0()
        {
            // Arrange
            var expectedOperationResult = new FizzBuzzOperationResults();
            expectedOperationResult.RunStatus = FizzBuzzOperationResultCodes.ObjectValueIsZero;
            expectedOperationResult.ResultDictionary = new Dictionary<DividendQuotientPair, string>();
            var expectedDictionaryOfResults = TestingFactory.GetDictionary();
            var listOfExpectedResult = new List<FizzBuzzOperationResults>()
            {
                expectedOperationResult,
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType, expectedDictionaryOfResults),
                expectedOperationResult,
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType, expectedDictionaryOfResults),
                expectedOperationResult,
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType, expectedDictionaryOfResults),
                expectedOperationResult,
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType, expectedDictionaryOfResults),
                expectedOperationResult,
                new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.InvalidType, expectedDictionaryOfResults)
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
                Assert.AreEqual(listOfExpectedResult[i].ResultDictionary.Count, listOfActualresults[i].ResultDictionary.Count);
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
            var actualresult = FizzBuzz.ExecuteFizzBuzz(supportedDateType, 10, 11);

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

        [TestMethod]
        public void ExecuteFizzBuzz_LowerNumberIsHigherThanHighNumber()
        {
            // Arrange
            var expectedResult = new FizzBuzzOperationResults(FizzBuzzOperationResultCodes.LowerNumberIsHigherThanHighNumber);
            var supportedDateType = new Cake("Chocolate", 10);
            var lowNumber = 100;

            var highNumber = 20;

            // Act
            var actualresult = FizzBuzz.ExecuteFizzBuzz(supportedDateType, lowNumber, highNumber);

            // Assert
            Assert.AreEqual(expectedResult.RunStatus, actualresult.RunStatus);
        }
    }
}
