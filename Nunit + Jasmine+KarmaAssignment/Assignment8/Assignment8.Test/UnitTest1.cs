using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

using FluentAssertions;
using System.Threading;
using System.Linq;
using FluentAssertions.Execution;

namespace Assignment8.Test
{
    /// <summary>
    /// Class contains 5 unit test cases for showing usage for fluent assertions
    /// </summary>
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// Test method for testing Enumerator methods as generic enumerable
        /// </summary>
        [Test]
        [Category("Enumerable")]
        public void Enumerator_AsGeneric()
        {
            // Arrange
            IEnumerable src = new int[] { 1, 2 };

            // Act
            var subject = src.GetEnumerator().AsGeneric<int>();
            subject.MoveNext().Should().BeTrue();
            subject.Current.Should().Be(1);
            subject.MoveNext().Should().BeTrue();
            subject.Current.Should().Be(2);
            subject.MoveNext().Should().BeFalse();
            subject.Reset();
            subject.MoveNext().Should().BeTrue();
            subject.Current.Should().Be(1);

            // Assert
            ((IEnumerator)subject).Current.Should().Be(1);
        }

        /// <summary>
        /// Test method for Testing Enumerable to string method
        /// </summary>
        [Test]
        [Category("Enumerable")]
        public void TestEnumerableToString()
        {
            // Arrange
            const string separator = ", ";
            var enumerable = new[] { 0, 1, 2, 3, 4 };
            const string whatEnumerableAsStringShouldBe = "0, 1, 2, 3, 4";

            // Act
            var enumerableAsString = enumerable.ToString(separator);
            
            // Assert
            using (new AssertionScope())
            {
                enumerableAsString.Should().NotBeNull();
                enumerableAsString.Should().Be(whatEnumerableAsStringShouldBe);
            }
        }

        /// <summary>
        /// Test method to test to check difference between two datetimes
        /// </summary>
        [Test]
        [Category("DateTime")]
        public void TestGetTimeNow()
        {
            // Arrange
            var time1 = DateTime.Now;
            Thread.Sleep(100);
            var time2 = DateTime.Now;

            // Assert
            (time2 - time1).TotalMilliseconds.Should().BeGreaterThan(90,"There should be difference of 1 second");
        }

        /// <summary>
        /// Testing method to check whether an Enumerable contains all unique items or not
        /// </summary>
        [Test]
        [Category("Enumerable")]
        public void TestGetUniqueItems()
        {
            // Arrange
            var times = Enumerable
                .Range(0, 10)
                .ToArray();

            // Assert
            using (new AssertionScope())
            {
                times.Should().NotBeNull();
                times.Should().HaveCount(10);
                times.Should().OnlyHaveUniqueItems();

            }
        }

        /// <summary>
        /// Test nethod for GetDivision method 
        /// </summary>
        [Test]
        [Category("Exception")]
        public void TestDivideByZeroException()
        {
            // Arrange
            Class1 c = new Class1();            
            
            // Act
            Action act = () => c.GetDivision();

            // Assert
            act.Should().Throw<DivideByZeroException>();
        }
    }
}