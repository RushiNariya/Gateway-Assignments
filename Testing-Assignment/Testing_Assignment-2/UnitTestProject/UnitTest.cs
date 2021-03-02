using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        string inputString = "";
        string expectedString = "";
        [TestMethod]
        public void UppartoLower()
        {
            //Arrange
            inputString = "Unit Test";
            expectedString = "uNIT tEST";
            //Act
            string outputString = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "UppartoLower");

            //Assert
            Assert.AreEqual(expectedString ,outputString);
        }

        [TestMethod]
        public void TitleCase()
        {
            //Arrange
            inputString = "unit TEST";
            expectedString = "Unit Test";
            //Act
            string outputString = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "TitleCase");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }

        [TestMethod]
        public void Capitalized()
        {
            //Arrange
            inputString = "unit test";
            expectedString = "Unit Test";
            //Act
            string outputString = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "Capitalized");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }

        [TestMethod]
        public void CheckLower()
        {
            //Arrange
            inputString = "unit test";
            expectedString = "lowerCase";
            //Act
            string outputString = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "CheckLower");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }

        [TestMethod]
        public void CheckUppar()
        {
            //Arrange
            inputString = "UNIT TEST";
            expectedString = "upparCase";
            //Act
            string outputString = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "CheckUppar");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }

        [TestMethod]
        public void CheckforInt()
        {
            //Arrange
            inputString = "100";
            expectedString = "Success";
            //Act
            string outputString = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "CheckforInt");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }

        [TestMethod]
        public void RemoveLastChar()
        {
            //Arrange
            inputString = "Unit Test";
            expectedString = "Unit Tes";
            //Act
            string outputString = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "RemoveLastChar");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }

        [TestMethod]
        public void WordCount()
        {
            //Arrange
            inputString = "Unit Test";
            expectedString = "9";
            //Act
            string outputString = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "WordCount");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }


        [TestMethod]
        public void StringToInt()
        {
            //Arrange
            inputString = "100";
            expectedString = "100";
            //Act
            string outputString = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "StringToInt");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }
    }
}
