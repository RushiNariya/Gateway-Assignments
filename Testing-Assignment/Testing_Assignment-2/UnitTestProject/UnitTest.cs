using System;
using Xunit;
using Testing_Assignment_2;

namespace UnitTestProject
{
    
    public class UnitTest
    {
        string inputString = "";
        string expected = "";
        [Fact]
        public void UppartoLower()
        {
            //Arrange
            inputString = "Unit Test";
            expected = "uNIT tEST";
            //Act
            string output = inputString.UppartoLower();

            //Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void TitleCase()
        {
            //Arrange
            inputString = "unit test";
            expected = "Unit Test";
            //Act
            string output = inputString.TitleCase();

            //Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void Capitalized()
        {
            //Arrange
            inputString = "unit test";
            expected = "Unit Test";
            //Act
            string output = inputString.Capitalized();

            //Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void CheckLower()
        {
            //Arrange
            inputString = "unittest";
            expected = "Success";
            //Act
            string output = inputString.CheckLower();

            //Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void CheckUppar()
        {
            //Arrange
            inputString = "UNITTEST";
            expected = "Success";
            //Act
            string output = inputString.CheckUppar();

            //Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void CheckforInt()
        {
            //Arrange
            inputString = "100";
            expected = "Success";
            //Act
            string output = inputString.CheckforInt();

            //Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void RemoveLastChar()
        {
            //Arrange
            inputString = "Unit Test";
            expected = "Unit Tes";
            //Act
            string output = inputString.RemoveLastChar();

            //Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void WordCount()
        {
            //Arrange
            inputString = "Unit Test";
            expected = "2";
            //Act
            string output = inputString.WordCount();

            //Assert
            Assert.Equal(expected, output);
        }


        [Fact]
        public void StringToInt()
        {
            //Arrange
            inputString = "100";
            expected = "100";
            //Act
            string output = inputString.StringToInt();

            //Assert
            Assert.Equal(expected, output);
        }
    }
}
