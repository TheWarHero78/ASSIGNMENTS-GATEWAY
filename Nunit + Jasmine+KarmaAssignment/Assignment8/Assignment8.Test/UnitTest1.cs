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
    [TestFixture]
    public class Tests
    {
        [Test]
        [Category("Enums")]
        public void Enumerator_AsGeneric()
        {
            IEnumerable src = new int[] { 1, 2 };

            var subject = src.GetEnumerator().AsGeneric<int>();

            subject.MoveNext().Should().BeTrue();
            subject.Current.Should().Be(1);
            subject.MoveNext().Should().BeTrue();
            subject.Current.Should().Be(2);
            subject.MoveNext().Should().BeFalse();

            subject.Reset();
            subject.MoveNext().Should().BeTrue();
            subject.Current.Should().Be(1);

            ((IEnumerator)subject).Current.Should().Be(1);
        }

        [Test]
        [Category("Enums")]
        public void TestEnumerableToString()
        {
            const string separator = ", ";
            var enumerable = new[] { 0, 1, 2, 3, 4 };
            const string whatEnumerableAsStringShouldBe = "0, 1, 2, 3, 4";
            var enumerableAsString = enumerable.ToString(separator);
            using (new AssertionScope())
            {
                enumerableAsString.Should().NotBeNull();
                enumerableAsString.Should().Be(whatEnumerableAsStringShouldBe);
            }
        }

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

        [Test]
        [Category("Enums")]
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

        [Test]
        [Category("Exception")]
        public void TestDivideByZeroException()
        {
            Class1 c = new Class1();            
            Action act = () => c.getDivision();
            act.Should().Throw<DivideByZeroException>();
        }
    }
}