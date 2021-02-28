using ExtensionMethods;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test_UpperToLower()
        {
            //Arrange
            var input = "AARSH";           
            var expectedValue = "aarsh";

            // Act
            var result = UtilityHelper.createLowerCase(input);

            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_LowerToUpper()
        {
            //Arrange
            var input = "aarsh";
            var expectedValue = "AARSH";
      
             // Act
             var result = UtilityHelper.createUpperCase(input);

            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_TitleCase()
        {
            //Arrange
            var input = "war and peace";
            var expectedValue = "War And Peace";

            // Act
            var result = UtilityHelper.ToTitleCase(input);

            //Assert
            Assert.Equal(expectedValue, result);
        }
        [Fact]
        public void Test_ValidateLowerCase()
        {
            //Arrange
            var input = "war and peace";
            var expectedValue = true;
            // Act
            var result = UtilityHelper.CheckLowerCase(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }
        [Fact]
        public void Test_ValidateUpperCase()
        {
            //Arrange
            var input = "AARSH";
            var expectedValue = true;
            // Act
            var result = UtilityHelper.CheckUpperCase(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }
        [Fact]
        public void Test_FisrtToUpper()
        {
            //Arrange
            var input = "aarsh";
            var expectedValue = "Aarsh";
            // Act
            var result = UtilityHelper.FirstLetterToUpper(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }
        [Fact]
        public void Test_ValidateNumeric()
        {
            //Arrange
            var input = "123";
            var expectedValue = true;
            // Act
            var result = UtilityHelper.ValidNumeric(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }
        [Fact]
        public void Test_RemoveLast()
        {
            //Arrange
            var input = "aarsh";
            var expectedValue = "aars";
            // Act
            var result = UtilityHelper.removeLastChar(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }
        [Fact]
        public void Test_GetWordCount()
        {
            //Arrange
            var input = "aarsh modi";
            var expectedValue = 2;
            // Act
            var result = UtilityHelper.GetWordCount(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }
        [Fact]
        public void Test_ConvertStringToInt()
        {
            //Arrange
            var input = "123";
            var expectedValue = 123;
            // Act
            var result = UtilityHelper.StringToInt(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }
    }
}
