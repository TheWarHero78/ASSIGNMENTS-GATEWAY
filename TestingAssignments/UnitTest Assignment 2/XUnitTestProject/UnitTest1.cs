using ExtensionMethods;
using System;
using Xunit;


namespace XUnitTestProject
{
    /// <summary>
    /// Unit Test Class 
    /// </summary>
    public class UnitTest1
    {
        [Fact]
        public void Test_UpperToLower()
        {
            // Arrange
            var input = "AARSH";
            var expectedValue = "aarsh";
            var input1 = "WORLD IS A good PLACE";
            var expectedValue1 = "world is a GOOD place";

            // Act
            var result = UtilityHelper.createLowerCase(input);
            var result1 = UtilityHelper.createLowerCase(input1);

            //Assert
            Assert.Equal(expectedValue, result);
            Assert.Equal(expectedValue1, result1);
        }

        [Fact]
        public void Test_LowerToUpper()
        {
            // Arrange
            var input = "aarsh";
            var expectedValue = "AARSH";

            // Act
            var result = UtilityHelper.createUpperCase(input);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_TitleCase()
        {
            // Arrange
            var input = "war and peace";
            var expectedValue = "War And Peace";
            var input1 = "21 and #eace";
            var expectedValue1 = "21 And #Eace";



            // Act
            var result = UtilityHelper.ToTitleCase(input);
            var result1 = UtilityHelper.ToTitleCase(input1);

            // Assert
            Assert.Equal(expectedValue, result);
            Assert.Equal(expectedValue1, result1);
        }
        [Fact]
        public void Test_ValidateLowerCase()
        {
            // Arrange
            var input = "war and peace";
            var expectedValue = true;

            var input1 = "war#@! and peace122";
            var expectedValue1 = true;

            // Act
            var result = UtilityHelper.CheckLowerCase(input);
            var result1 = UtilityHelper.CheckLowerCase(input1);

            // Assert
            Assert.Equal(expectedValue, result);
            Assert.Equal(expectedValue1, result1);
        }
        [Fact]
        public void Test_ValidateUpperCase()
        {
            // Arrange
            var input = "AARSH";
            var expectedValue = true;

            var input1 = "#@1D343";
            var expectedValue1 = true;


            // Act
            var result = UtilityHelper.CheckUpperCase(input);
            var result1 = UtilityHelper.CheckUpperCase(input1);

            // Assert
            Assert.Equal(expectedValue, result);
            Assert.Equal(expectedValue1, result1);
        }
        [Fact]
        public void Test_FisrtToUpper()
        {
            // Arrange
            var input = "aarsh";
            var expectedValue = "Aarsh";
            var input1 = "#ggfgf";
            var expectedValue1 = "#ggfgf";

            // Act
            var result = UtilityHelper.FirstLetterToUpper(input);
            var result1 = UtilityHelper.FirstLetterToUpper(input1);
            // Assert
            Assert.Equal(expectedValue, result);
            Assert.Equal(expectedValue1, result1);
        }
        [Fact]
        public void Test_ValidateNumeric()
        {
            // Arrange
            var input = "123";
            var expectedValue = true;
            var input1 = "@!@!#21";
            var expectedValue1 = false;

            // Act
            var result = UtilityHelper.ValidNumeric(input);
            var result1 = UtilityHelper.ValidNumeric(input1);

            // Assert
            Assert.Equal(expectedValue, result);
            Assert.Equal(expectedValue1, result1);
        }
        [Fact]
        public void Test_RemoveLast()
        {
            // Arrange
            var input = "aarsh";
            var expectedValue = "aars";

            var input1 = "a ";
            var expectedValue1 = "a";


            // Act
            var result = UtilityHelper.removeLastChar(input);
            var result1 = UtilityHelper.removeLastChar(input1);

            // Assert
            Assert.Equal(expectedValue, result);
            Assert.Equal(expectedValue1, result1);
        }
        [Fact]
        public void Test_GetWordCount()
        {
            // Arrange
            var input = "aarsh modi";
            var expectedValue = 2;

            var input1 = "  ";
            var expectedValue1 = 2;


            // Act
            var result = UtilityHelper.GetWordCount(input);
            var result1 = UtilityHelper.GetWordCount(input1);

            // Assert
            Assert.Equal(expectedValue, result);
            Assert.Equal(expectedValue1, result1);
        }
        [Fact]
        public void Test_ConvertStringToInt()
        {
            // Arrange
            var input = "123";
            var expectedValue = 123;




            // Act
            var result = UtilityHelper.StringToInt(input);



            // Assert
            Assert.Equal(expectedValue, result);


        }
    }
}
